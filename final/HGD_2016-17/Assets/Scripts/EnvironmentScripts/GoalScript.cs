using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalScript : MonoBehaviour
{
    private GameObject player;
    public GameObject uiManager;
    //private UIManagerScript uiManagerScript;
    public string nextLevelName;

    bool triggered = false;
    float scale = 1;

    // Use this for initialization
    void Start()
    {
        triggered = false;
        player = GameObject.FindWithTag("Player");
        //uiManagerScript = uiManager.GetComponent<UIManagerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggered)
        {
            scale -= Time.deltaTime / 1;

            if (scale <= .01)
            {
                SceneManager.LoadScene(nextLevelName);
                triggered = false;
            }

            player.transform.localScale = new Vector3(scale, scale, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        // If the player colllides with the goal, go to the next level
        if (obj.gameObject == player)
        {
            triggered = true;
        }
    }
}