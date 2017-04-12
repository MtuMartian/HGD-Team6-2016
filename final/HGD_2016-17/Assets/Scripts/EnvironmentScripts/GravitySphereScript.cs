using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GravitySphereScript : MonoBehaviour {
	
	private GameObject player;
	public bool activated;
	public float strength = 10;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // If the gravity sphere is activated, apply a force relative to the distance between the gravity
        // sphere and the player.
		if (activated) {
			player.GetComponent<Rigidbody2D> ().AddForce ((transform.position - player.transform.position)
			/ ((float)Math.Pow (Vector2.Distance (transform.position, player.transform.position), 2)) * strength);
		}
	}
}
