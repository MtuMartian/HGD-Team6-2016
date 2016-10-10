using UnityEngine;
using System.Collections;

public class CameraRotateScript : MonoBehaviour {

    public float rotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0, 0, -rotateSpeed);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(0, 0, rotateSpeed);
	}
}
