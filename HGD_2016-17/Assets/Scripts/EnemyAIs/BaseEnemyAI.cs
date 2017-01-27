using UnityEngine;
using System.Collections;

public abstract class BaseEnemyAI : MonoBehaviour
{
    public float patience = 2f;
    protected GameObject player;
    protected AIState currentState = AIState.IDLE;
    private float timeOnCurrentState = 0f;


	// Use this for initialization
	protected virtual void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
        timeOnCurrentState += Time.fixedDeltaTime;
        switch (currentState)
        {
            case AIState.IDLE:
                IdleAction();
                break;
            case AIState.ALERT:
                AlertAction();
                if (timeOnCurrentState >= patience)
                {
                    ChangeState(AIState.ATTACK);
                    timeOnCurrentState = 0f;
                }   
                break;
            case AIState.ATTACK:
                AttackAction();
                break;
        }
	}

    protected abstract void IdleAction();

    protected abstract void AlertAction();

    protected abstract void AttackAction();

    protected virtual void ChangeState(AIState newState)
    {
        currentState = newState;
        timeOnCurrentState = 0f;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject == player)
        {
            ChangeState(AIState.ALERT);
            timeOnCurrentState = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject == player)
        {
            ChangeState(AIState.IDLE);
            timeOnCurrentState = 0f;
        }
    }

    protected enum AIState
    {
        IDLE,
        ALERT,
        ATTACK
    };
}
