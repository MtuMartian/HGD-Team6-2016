using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainScreenUIManger : MonoBehaviour {

    public Button newGameBtn;
    public Button resumeBtn;
    public Button optionsBtn;
    public Button exitBtn;
 
	// Use this for initialization
	void Start () {
        newGameBtn.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("MilesTutorial01");
            Debug.Log("New Game Button was pressed");
        });
        resumeBtn.onClick.AddListener(delegate
        {
            Debug.Log("Resume Game Button was pressed");
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
	
	// Update is called once per frame
	void Update () {
	    
	}

}
