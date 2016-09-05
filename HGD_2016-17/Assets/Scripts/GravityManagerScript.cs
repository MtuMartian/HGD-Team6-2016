using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class GravityManagerScript : MonoBehaviour {

	private IEnumerable<GameObject> gravitySpheres;
	private IEnumerable<GameObject> moveableObjects;
	private bool _isGravityEnabled;

	void Start () {	}

	void FixedUpdate () {
		moveableObjects = (GameObject.FindObjectsOfType (typeof(GameObject)) as IEnumerable<GameObject>)
			.Where (obj => (obj as GameObject).layer == LayerMask.NameToLayer("MoveableObjects"));
		
		_isGravityEnabled = !Input.GetKey (KeyCode.Z);
		if (!_isGravityEnabled) {
			gravitySpheres = (GameObject.FindObjectsOfType (typeof(GameObject)) as IEnumerable<GameObject>)
				.Where (obj => (obj as GameObject).layer == LayerMask.NameToLayer ("GravitySpheres")); 

			moveableObjects.ToList ().ForEach (obj => {
				gravitySpheres.ToList ().ForEach (sphere => {
					obj.GetComponent<Rigidbody2D> ().AddForce ((sphere.transform.position - obj.transform.position) 
						/ ((float) Math.Pow(Vector2.Distance(sphere.transform.position, obj.transform.position), 2)) * 10);
				});
				obj.GetComponent<Rigidbody2D> ().gravityScale = 0;
			});
		} else {
			moveableObjects.ToList ().ForEach (obj => {
				obj.GetComponent<Rigidbody2D> ().gravityScale = 1;
			});
		}
	}
}
