using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Text mainText;
    public Text subText;
    public Button resumeBtn;
    public Button restartBtn;
    public Button mainMenuBtn;
    public Button quitBtn;
	private GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManagerScript>();
        resumeBtn.onClick.AddListener(() => gameManager.isPaused = false);
        restartBtn.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        mainMenuBtn.onClick.AddListener(() => SceneManager.LoadScene("TitleMenu"));
        quitBtn.onClick.AddListener(() => Application.Quit());

        ClearMessage();
	}
	
	// Update is called once per frame
	void Update () {
        SetMenuState(gameManager.isPaused);
	}

    public void SetMenuState(bool state)
    {
        resumeBtn.GetComponent<Image>().enabled = state;
        resumeBtn.GetComponentInChildren<Text>().enabled = state;
        restartBtn.GetComponent<Image>().enabled = state;
        restartBtn.GetComponentInChildren<Text>().enabled = state;
        mainMenuBtn.GetComponent<Image>().enabled = state;
        mainMenuBtn.GetComponentInChildren<Text>().enabled = state;
        quitBtn.GetComponent<Image>().enabled = state;
        quitBtn.GetComponentInChildren<Text>().enabled = state;
    }

    // Reveals the text elements and displays a message to the user.
    // TODO: Make this account for if the game is paused (and menu is showing)
	public void DisplayMessage(string message, string subMessage = "", int time = 0) {
		mainText.GetComponent<Text>().text = message;
		mainText.GetComponent<Text>().enabled = true;
		subText.GetComponent<Text> ().text = subMessage;
		subText.GetComponent<Text> ().enabled = true;
	}

    // Hides the text elements that display messages to the user
	public void ClearMessage() {
		mainText.GetComponent<Text>().text = "";
		mainText.GetComponent<Text>().enabled = false;
		subText.GetComponent<Text> ().text = "";
		subText.GetComponent<Text> ().enabled = false;
	}
}
