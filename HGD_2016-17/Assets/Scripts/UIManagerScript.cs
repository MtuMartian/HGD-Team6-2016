using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Text mainText;
    public Text subText;
    public Button resumeBtn;
    public Button mainMenuBtn;
    public Button quitBtn;
	private GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManagerScript>();
        resumeBtn.onClick.AddListener(() => gameManager.isPaused = false);
        mainMenuBtn.onClick.AddListener(() => SceneManager.LoadScene("TitleMenu"));
        quitBtn.onClick.AddListener(() => Application.Quit());

        ClearMessage();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isPaused)
            DisplayMenu();
        else 
            HideMenu();
	}

    public void DisplayMenu() {
        resumeBtn.GetComponent<Image>().enabled = true;
        resumeBtn.GetComponentInChildren<Text>().enabled = true;
        mainMenuBtn.GetComponent<Image>().enabled = true;
        mainMenuBtn.GetComponentInChildren<Text>().enabled = true;
        quitBtn.GetComponent<Image>().enabled = true;
        quitBtn.GetComponentInChildren<Text>().enabled = true;
    }

    public void HideMenu() {
        resumeBtn.GetComponent<Image>().enabled = false;
        resumeBtn.GetComponentInChildren<Text>().enabled = false;
        mainMenuBtn.GetComponent<Image>().enabled = false;
        mainMenuBtn.GetComponentInChildren<Text>().enabled = false;
        quitBtn.GetComponent<Image>().enabled = false;
        quitBtn.GetComponentInChildren<Text>().enabled = false;
    }

	public void DisplayMessage(string message, string subMessage = "", int time = 0) {
		mainText.GetComponent<Text>().text = message;
		mainText.GetComponent<Text>().enabled = true;
		subText.GetComponent<Text> ().text = subMessage;
		subText.GetComponent<Text> ().enabled = true;
	}

	public void ClearMessage() {
		mainText.GetComponent<Text>().text = "";
		mainText.GetComponent<Text>().enabled = false;
		subText.GetComponent<Text> ().text = "";
		subText.GetComponent<Text> ().enabled = false;
	}
}
