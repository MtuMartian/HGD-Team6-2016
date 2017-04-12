using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickupUIElementScript : MonoBehaviour {

    public Text countText;
    private GameObject player;
    public PickupScript.PickupType type;

    private int count 
    {
        get 
        {
            PlayerMovementScript ps = player.GetComponent<PlayerMovementScript>();
            // If the player's pickup dictionary contains the type, return how many it contains
            return ps.pickupDictionary.ContainsKey(type) ? ps.pickupDictionary[type] : 0;
        }
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        countText.text = ": " + count;
	}
}
