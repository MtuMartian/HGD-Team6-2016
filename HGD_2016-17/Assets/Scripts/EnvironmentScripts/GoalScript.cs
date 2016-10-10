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
		if (obj.gameObject == player)
			SceneManager.LoadScene (nextLevelName);

			//uiManagerScript.DisplayMessage("You win!", "(Win handling will be updated later...)", 10000);
    }

	void GoToNextLevel() {
		SceneManager.LoadScene (nextLevelName);
	}
}
