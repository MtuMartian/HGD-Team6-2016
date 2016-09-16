using System;
using UnityEngine;

public class BaseGameObject : MonoBehaviour	{
	
	protected GameManagerScript gameManager;
	void Start() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManagerScript>();
	}
	void Update() {
		if (gameManager == null)
			gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManagerScript>();
		if (gameManager.isPaused)
			return;
	}
	void FixedUpdate() {
		Debug.Log ("THIS IS A TEST!!!");
		if (gameManager.isPaused)
			return;
	}
}

