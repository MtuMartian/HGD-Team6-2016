using UnityEngine;
using System;
using System.Linq;
using System.Collections;

/// <summary>
/// This script is attached to the camera. It locates the player using tags and then smoothly follows the 
/// player's orientation and position.
/// </summary>
public class CameraFollow : MonoBehaviour {

	private Transform playerTransform;
	private PlayerMovementScript playerScript;
	public float dampening; // Dampening controls how smoothly the camera follows the player's position
	public float rotationalDampening; // Controls how smoothly the camera follows the player's rotation

    // This vector is required to give a reference to the camera's current velocity in order to smoothly
    // follow the player
    private Vector3 velocity = Vector3.zero; 

	// Initialize references to player transform and the player script
	void Start () {
        var player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
		playerScript = player.GetComponent<PlayerMovementScript> ();
	}
	
    // This function is called on fixed intervals
	void FixedUpdate () {
		UpdatePosition ();
		UpdateRotation ();
	}

	void UpdatePosition() {
        // Get the z position in order to lock the camera in place on the z-axis
        var z = transform.position.z;
        // Get the current position
		Vector3 currentPosition = transform.position;
        // Get the difference between the camera's current position and the player's current position
		Vector3 delta = new Vector3 (
			playerTransform.position.x - currentPosition.x,
			playerTransform.position.y - currentPosition.y,
			currentPosition.z); // z is fixed
        // The desired position is equal to the current position + the difference between the object's position
		Vector3 finalPosition = currentPosition + delta;
        // Uses the SmoothDamp method to smoothly move the camera towards the desired final position
		Vector3 smoothMovement = Vector3.SmoothDamp (currentPosition, finalPosition, ref velocity, dampening);
		// Update camera position
        transform.position = new Vector3(smoothMovement.x, smoothMovement.y, z);
	}

	void UpdateRotation() {
        // Only rotate the camera automatically if the player is within the influence of any spheres
		if (playerScript.influencingSpheres.Any ()) {
            // Gain a reference to the player's primary influencing sphere
            // TODO: Update logic behind finding primary influencing sphere
            var sphere = playerScript.influencingSphere;
            // Calculate delta vector
			Vector3 v3 = playerTransform.position - sphere.transform.position;
			v3 = new Vector3 (v3.x, v3.y, 0);
            // Smoothly update the camera's rotation using Slerp method
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, v3), rotationalDampening);
		}
	}
}
