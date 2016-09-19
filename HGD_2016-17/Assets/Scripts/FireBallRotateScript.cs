using UnityEngine;
using System.Collections;

public class FireBallRotateScript : MonoBehaviour {

	public GameObject parent;
	public GameObject player;
	public GameObject uiManager;
	public float rotateSpeed;
	private UIManagerScript uiManagerScript;
	private GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
		uiManagerScript = uiManager.GetComponent<UIManagerScript> ();
		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManagerScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.RotateAround (parent.transform.position, new Vector3 (0, 0, 1), rotateSpeed);
	}

	void OnTriggerEnter2D(Collider2D obj) {
		if (obj.gameObject == player) {
			uiManagerScript.DisplayMessage ("Game Over!", "Press Space to continue...", 10000);
			gameManager.isPaused = true;
		}
	}
}
