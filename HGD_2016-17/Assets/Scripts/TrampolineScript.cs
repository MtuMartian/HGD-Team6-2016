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

	void OnCollisionEnter2D(Collision2D obj) {
		obj.transform.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Mathf.Cos(Mathf.Deg2Rad * transform.rotation.z),
			Mathf.Sin(Mathf.Deg2Rad * transform.rotation.z)) * power);
	}
}
