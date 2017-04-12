using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SentryEnemyAI : BaseEnemyAI
{
    public float laserCooldown = 4f; // Laser cooldown in seconds
    private float timeSinceLastLaser = 4f;
    public GameObject laserObject;

    protected override void Start()
    {
        base.Start();
        patience = laserCooldown;
    }

    protected override void AlertAction()
    {
        
    }

    protected override void AttackAction()
    {
        
    }

    protected override void IdleAction()
    {
        
    }

    protected override void ChangeState(AIState newState)
    {
        base.ChangeState(newState);
        switch (newState)
        {
            case AIState.IDLE:
                // Indicate that turret is doing nothing
                //GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case AIState.ALERT:
                // Indicate that the turret is alert
                break;
            case AIState.ATTACK:
                // Fire a laser or something...
                //GetComponent<SpriteRenderer>().color = Color.red;
                GameObject laser = Instantiate(laserObject);
                var laserScript = laser.GetComponent<LaserScript>();
                laserScript.Init(this.gameObject);
                ChangeState(AIState.ALERT);
                break;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
