using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private AIState currentState = AIState.IDLE;
    private float timeOnCurrentState = 0f;
    private float patience = 2f;
    private Vector3 shakeOffset = Vector3.one;


	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timeOnCurrentState += Time.fixedDeltaTime;
        Debug.Log(currentState);
        switch (currentState)
        {
            case AIState.IDLE:
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case AIState.ALERT:
                Debug.Log("ENEMY WILL SHAKE");
                Shake();
                if (timeOnCurrentState >= patience)
                {
                    currentState = AIState.ATTACK;
                    timeOnCurrentState = 0f;
                    GetComponent<SpriteRenderer>().color = Color.red;
                }   
                break;
            case AIState.ATTACK:
                Debug.Log("ENEMY IS ANGRY");
                break;
        }
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject == player)
        {
            currentState = AIState.ALERT;
            Debug.Log("ENEMY HAS NOTICED PLAYER");
            timeOnCurrentState = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject == player)
        {
            currentState = AIState.IDLE;
            Debug.Log("ENEMY NO LONGER SEES PLAYER");
            timeOnCurrentState = 0f;
        }
    }

    void Shake()
    {
        float xOffset = Mathf.Sin(Time.time * 40f) * 0.08f;
        Debug.Log("xOffset: " + xOffset);
        shakeOffset = new Vector3(xOffset, 0, 0);
        transform.position += shakeOffset;
    }

    private enum AIState
    {
        IDLE,
        ALERT,
        ATTACK
    };
}
