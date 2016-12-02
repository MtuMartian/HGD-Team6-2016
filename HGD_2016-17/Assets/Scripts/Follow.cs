using UnityEngine;
using System.Collections;

/// <summary>
/// Attach this script to a gameobject and give it a reference to another object to make the 
/// original object follow the other object
/// </summary>
public class Follow : MonoBehaviour {
	
	public GameObject objectToFollow;

	void Start () {}

	void FixedUpdate () {
		transform.position = objectToFollow.transform.position;
	}
}
