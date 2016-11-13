using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalScript : MonoBehaviour {

    private GameObject player;
    public GameObject uiManager;
    private UIManagerScript uiManagerScript;
	public string nextLevelName;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        uiManagerScript = uiManager.GetComponent<UIManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D (Collision2D obj) {
        // If the player colllides with the goal, go to the next level
		if (obj.gameObject == player)
			SceneManager.LoadScene (nextLevelName);
    }
}
