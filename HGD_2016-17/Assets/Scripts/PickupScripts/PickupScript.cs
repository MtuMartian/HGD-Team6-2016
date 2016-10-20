using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    public PickupType type;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // When the player enters the trigger collider, to the player to collect the pickup
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject == player)
        {
            Destroy(transform.gameObject);
            player.GetComponent<PlayerMovementScript>().CollectPickup(this);
        }
    }

    // An enum to keep track of the types of pickup objects
    public enum PickupType
    {
        INCREASE,
        DECREASE,
        REVERSE
    }
}
