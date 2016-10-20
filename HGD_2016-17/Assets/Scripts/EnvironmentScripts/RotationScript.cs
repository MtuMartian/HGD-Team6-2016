using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

	public GameObject parent;
	public float rotateSpeed;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (parent.transform.position, new Vector3 (0, 0, 1), rotateSpeed);
	}
}
