using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainScreenUIManger : MonoBehaviour {

	public Button[] buttons;

	[Space(10)]
    private Button newGameBtn;
	private Button resumeBtn;
	private Button levelBtn;
	private Button optionsBtn;
	private Button exitBtn;
 
	// Use this for initialization
	void Start () {
		foreach (Button b in buttons) {
			switch (b.name) {
			case "NewGameBtn":
				newGameBtn = b;
				break;
			case "ResumeBtn":
				resumeBtn = b;
				break;
			case "LevelSelectBtn":
				levelBtn = b;
				break;
			case "OptionsBtn":
				optionsBtn = b;
				break;
			case "ExitBtn":
				exitBtn = b;
				break;
			}
		}

        newGameBtn.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("MilesTutorial01");
            Debug.Log("New Game Button was pressed");
        });
        resumeBtn.onClick.AddListener(delegate
        {
            Debug.Log("Resume Game Button was pressed");
        });
		levelBtn.onClick.AddListener (delegate
		{
			Debug.Log ("Level Select Button was pressed");
		});
        optionsBtn.onClick.AddListener(delegate
        {
            Debug.Log("Options Button was pressed");
        });
        exitBtn.onClick.AddListener(delegate
        {
            Application.Quit();
            Debug.Log("Exit Button was pressed");
        });
    }
}
