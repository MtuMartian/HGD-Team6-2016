using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float speed = 1f;

	void Update () {
		transform.RotateAround (transform.parent.position, new Vector3 (0, 0, 1), speed * Time.deltaTime);
	}
}
