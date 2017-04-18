using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public GameObject container;
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
	}
	
	// Update is called once per frame
	void Update () {
        SetMenuState(gameManager.isPaused);
	}

    public void SetMenuState(bool state)
    {
		container.SetActive (state);
    }
}
