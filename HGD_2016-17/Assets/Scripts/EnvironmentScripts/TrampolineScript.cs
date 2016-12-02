using UnityEngine;
using System.Collections;

public class TrampolineScript : MonoBehaviour {

	public float power;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    // When an object hits the collider, apply a force on it in the direction of the jump pad
	void OnCollisionEnter2D(Collision2D obj) {
		Vector2 force = new Vector2 (
			                -1 * Mathf.Sin (Mathf.Deg2Rad * transform.rotation.eulerAngles.z),
			                1 * Mathf.Cos (Mathf.Deg2Rad * transform.rotation.eulerAngles.z));
		obj.transform.GetComponent<Rigidbody2D> ().AddForce (force * power);
	}
}
