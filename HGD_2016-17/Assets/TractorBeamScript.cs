using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TractorBeamScript : MonoBehaviour {

	public float strength;
	private List<GameObject> objects;

	// Use this for initialization
	void Start () {
		objects = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		objects.ForEach (obj => {
			Vector2 force = new Vector2 (
				-1 * Mathf.Sin (Mathf.Deg2Rad * transform.rotation.eulerAngles.z),
				1 * Mathf.Cos (Mathf.Deg2Rad * transform.rotation.eulerAngles.z));
			obj.GetComponent<Rigidbody2D>().AddForce(force * strength);
		});
	}

	void OnTriggerEnter2D(Collider2D obj) {
		objects.Add (obj.gameObject);
	}

	void OnTriggerExit2D(Collider2D obj) {
		objects.Remove (obj.gameObject);
	}
}
