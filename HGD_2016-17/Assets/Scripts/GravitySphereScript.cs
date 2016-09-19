using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GravitySphereScript : MonoBehaviour {
	
	public GameObject player;
	public bool activated;
	public float strength = 10;
    public Button btn;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (activated) {
			player.GetComponent<Rigidbody2D> ().AddForce ((transform.position - player.transform.position)
			/ ((float)Math.Pow (Vector2.Distance (transform.position, player.transform.position), 2)) * strength);
		}
	}
}
