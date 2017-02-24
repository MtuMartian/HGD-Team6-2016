using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AttachEnemyAI : BaseEnemyAI
{
    public AudioClip shake;
    public AudioClip attack;
    public AudioSource es;
    private bool isAttached = false;
    private Vector3 shakeOffset = Vector3.one;
    public float chaseSpeed = 50f;
    private string state; 

    protected override void IdleAction()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    protected override void AlertAction()
    {
        Shake();
    }

    protected override void AttackAction()
    {
        if (isAttached)
        {
            var playerBody = player.GetComponent<Rigidbody2D>();
            var playerVel = playerBody.velocity;
            playerBody.AddForce(playerVel * -10f);
            Charge(chaseSpeed / 4f);
        }
        else
        {
            Charge();
        }
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void Shake()
    {
        float xOffset = Mathf.Sin(Time.time * 40f) * 0.08f;
        shakeOffset = new Vector3(xOffset, 0, 0);
        transform.position += shakeOffset;
    }

    private void Charge(float speed = -1)
    {
        var playerPos = player.transform.position;
        var currentPos = transform.position;
        var delPos = (playerPos - currentPos).normalized;
        var body = GetComponent<Rigidbody2D>();
        body.AddForce(delPos * (speed > 0 ? speed : chaseSpeed));
    }

    protected void FixedUpdate()
    {
        base.FixedUpdate();
        var playerPos = player.transform.position;
        var currentPos = transform.position;
        if (Vector2.Distance(playerPos, currentPos) < 3f) 
        {
            isAttached = true;
        }
        else
        {
            isAttached = false;
        }
    }
          protected override void ChangeState(AIState newState)
    {
        base.ChangeState(newState);
        if (newState == AIState.ALERT)
        {
            es.clip = shake;
            es.Play();
        }
        else if (newState == AIState.ATTACK)
        {
            es.clip = attack;
            es.Play();
        } else
        {
            es.Stop();
        }
    }
    private  void CheckState(AIState newState)
    {
        base.ChangeState(newState);
        if (newState == AIState.ALERT)
        {

          getState("Alert"); 
        }
        else if (newState == AIState.ATTACK)
        {
            getState("Attack");
        }
        else
        {
            getState("Idle");
        }
    }
    private  void getState(string state)
    {
        this.state = state;
    }
    public string WhatState()
    {
        return state; 
    }
}
