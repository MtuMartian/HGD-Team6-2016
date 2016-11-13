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
        // Apply a constant force on each object within the list of contained objects
		objects.ForEach (obj => {
			Vector2 force = new Vector2 (
				-1 * Mathf.Sin (Mathf.Deg2Rad * transform.rotation.eulerAngles.z),
				1 * Mathf.Cos (Mathf.Deg2Rad * transform.rotation.eulerAngles.z));
			obj.GetComponent<Rigidbody2D>().AddForce(force * strength);
		});
	}

    // When an object enters the trigger collider, add it to the list of objects
	void OnTriggerEnter2D(Collider2D obj) {
		objects.Add (obj.gameObject);
	}
    
    // When an object leaves the trigger collider, remove it from the list of objects
	void OnTriggerExit2D(Collider2D obj) {
		objects.Remove (obj.gameObject);
	}
}
