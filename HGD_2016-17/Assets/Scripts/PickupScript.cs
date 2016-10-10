using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    public enum PickupType {
        INCREASE,
        DECREASE,
        REVERSE
    }

    public PickupType type;
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject == player)
        {
            Destroy(transform.gameObject);
            player.GetComponent<PlayerMovementScript>().CollectPickup(this);
        }
    }
}
