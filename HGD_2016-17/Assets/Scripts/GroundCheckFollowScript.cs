using UnityEngine;
using System.Collections;

public class GroundCheckFollowScript : MonoBehaviour {

	public GameObject player;
	public float offsetDistance = 3.8f;
	private GameObject currentSphere
	{
		get 
		{ 
			return player.GetComponent<PlayerMovementScript> ().influencingSphere != null ?
					player.GetComponent<PlayerMovementScript> ().influencingSphere.gameObject 
					: null; 
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentSphere != null) {
			var offset = (player.transform.position - currentSphere.transform.position).normalized * offsetDistance;
			transform.position = player.transform.position - offset;
		}
	}
}
