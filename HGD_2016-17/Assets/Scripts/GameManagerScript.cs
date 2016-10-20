using UnityEngine;
using System.Collections;
using System.IO;

public class GameManagerScript : MonoBehaviour {

	public bool isPaused = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // Pressing the escape key will pause the game.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        // Update the timescale depending on if the game is paused
        Time.timeScale = isPaused ? 0 : 1;
    }
}
