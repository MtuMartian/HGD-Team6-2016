using UnityEngine;
using System.Collections;
using System;

public class CameraFollow : MonoBehaviour {

	public Transform playerTransform;
	public float dampening;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var z = transform.position.z;
		Vector3 currentPosition = transform.position;
		Vector3 delta = new Vector3 (
			                playerTransform.position.x - currentPosition.x,
			                playerTransform.position.y - currentPosition.y,
			                currentPosition.z);
		Vector3 finalPosition = currentPosition + delta;
		Vector3 smoothMovement = Vector3.SmoothDamp (currentPosition, finalPosition, ref velocity, dampening);
		transform.position = new Vector3(smoothMovement.x, smoothMovement.y, z);
	}
}
