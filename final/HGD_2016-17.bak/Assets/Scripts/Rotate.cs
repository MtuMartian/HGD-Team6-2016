using UnityEngine;
using System.Collections;

/// <summary>
/// This script causes a game object to rotate around its parent object in its hierarchy
/// </summary>
public class Rotate : MonoBehaviour {
	public float speed = 1f;

	void Update () {
		transform.RotateAround (transform.parent.position, new Vector3 (0, 0, 1), speed * Time.deltaTime);
	}
}
