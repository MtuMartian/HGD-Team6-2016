using UnityEngine;
using System.Collections;
using System.Linq;

public abstract class BaseEnemyAI : MonoBehaviour
{
    public float patience = 2f;
    protected GameObject player;
    protected AIState currentState = AIState.IDLE;
    private float timeOnCurrentState = 0f;

    private SpriteAnimator idleAnimation;
    private SpriteAnimator alertAnimation;
    private SpriteAnimator attackAnimation;

	// Use this for initialization
	protected virtual void Start () {
        player = GameObject.FindWithTag("Player");
        var animators = GetComponents<SpriteAnimator>();
        idleAnimation = animators.Where(script => script.id == 0).First();
        alertAnimation = animators.Where(script => script.id == 1).First();
        attackAnimation = animators.Where(script => script.id == 2).First();
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
        idleAnimation.enabled = newState == AIState.IDLE;
        alertAnimation.enabled = newState == AIState.ALERT;
        attackAnimation.enabled = newState == AIState.ATTACK;

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
