using UnityEngine;
using System.Collections;

public class FireBallRotateScript : MonoBehaviour {

    // Fireball rotates around parent object
	public GameObject parent;
	private GameObject player;
    // Fireball uses uiManager to display a message when the player hits a fireball
	public GameObject uiManager;
    // Controls how quickly the fireball rotates around the parent
	public float rotateSpeed;
	private UIManagerScript uiManagerScript;
	private GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        uiManagerScript = uiManager.GetComponent<UIManagerScript> ();
		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManagerScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.RotateAround (parent.transform.position, new Vector3 (0, 0, 1), rotateSpeed);
	}

    // OnTriggerEnter2D is called whenever an object with a collider enters the collider component of the
    // GameObject this script is attached to
	void OnTriggerEnter2D(Collider2D obj) {
        // Check if the player was hit
		if (obj.gameObject == player) {
            // Alert the player that the game has ended
			uiManagerScript.DisplayMessage ("Game Over!", "Press Space to continue...", 10000);
            // Pause the game. TODO: This should restart the level with some sort of indication/delay
			gameManager.isPaused = true;
		}
	}
}
