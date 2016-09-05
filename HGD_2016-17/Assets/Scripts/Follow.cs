using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public GameObject objectToFollow;

	void Start () {}

	void FixedUpdate () {
		transform.position = objectToFollow.transform.position;
	}
}
