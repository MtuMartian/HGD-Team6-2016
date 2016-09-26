using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.parent.position, new Vector3 (0, 0, 1), speed * Time.deltaTime);
	}
}
