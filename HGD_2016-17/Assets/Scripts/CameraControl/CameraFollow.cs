using UnityEngine;
using System;
using System.Linq;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private GameObject player;
	private Transform playerTransform;
	private PlayerMovementScript playerScript;
	public float dampening;
	public float rotationalDampening;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
		playerScript = player.GetComponent<PlayerMovementScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		UpdatePosition ();
		UpdateRotation ();
	}

	void UpdatePosition() {
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

	void UpdateRotation() {
		if (playerScript.influencingSpheres.Any ()) {
			var sphere = playerScript.influencingSpheres.First ();
			Vector3 v3 = playerTransform.position - sphere.transform.position;
			v3 = new Vector3 (v3.x, v3.y, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, v3), rotationalDampening);
		}
	}
}
