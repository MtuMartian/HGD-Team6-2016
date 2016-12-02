using UnityEngine;
using System.Collections;

public class GroundCheckFollowScript : MonoBehaviour {

	private GameObject player;
	public float offsetDistance = 3.8f;
    
    // Returns the current influencing sphere of the player
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
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		if (currentSphere != null) {
            // Update the position of the ground check object if the player is within a gravity sphere
			var offset = (player.transform.position - currentSphere.transform.position).normalized * offsetDistance;
			transform.position = player.transform.position - offset;
		}
	}
}
