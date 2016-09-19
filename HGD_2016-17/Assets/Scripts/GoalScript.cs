using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    public GameObject player;
    public GameObject uiManager;
    private UIManagerScript uiManagerScript;

    // Use this for initialization
    void Start () {
        uiManagerScript = uiManager.GetComponent<UIManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D (Collision2D obj) {
        if (obj.gameObject == player)
            uiManagerScript.DisplayMessage("You win!", "(Win handling will be updated later...)", 10000);
    }
}
