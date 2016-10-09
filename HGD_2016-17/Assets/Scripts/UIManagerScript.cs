using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public GameObject mainText;
	public GameObject subText;
	private GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManagerScript>();
		ClearMessage ();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isPaused)
            DisplayMessage("Game Paused", "Press 'Escape' To Continue");
        else
            ClearMessage();
	}

	public void DisplayMessage(string message, string subMessage = "", int time = 0) {
		mainText.GetComponent<Text>().text = message;
		mainText.GetComponent<Text>().enabled = true;
		subText.GetComponent<Text> ().text = subMessage;
		subText.GetComponent<Text> ().enabled = true;
	}

	public void ClearMessage() {
		mainText.GetComponent<Text> ().text = "";
		mainText.GetComponent<Text> ().enabled = false;
		subText.GetComponent<Text> ().text = "";
		subText.GetComponent<Text> ().enabled = false;
	}
}
