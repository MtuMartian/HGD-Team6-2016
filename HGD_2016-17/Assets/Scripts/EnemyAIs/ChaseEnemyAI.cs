using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ChaseEnemyAI : BaseEnemyAI
{
    public float chaseSpeed = 50f;
    private Vector3 shakeOffset = Vector3.one;

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
        Charge();
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void Shake()
    {
        float xOffset = Mathf.Sin(Time.time * 40f) * 0.08f;
        shakeOffset = new Vector3(xOffset, 0, 0);
        transform.position += shakeOffset;
    }

    private void Charge()
    {
        var playerPos = player.transform.position;
        var currentPos = transform.position;
        var delPos = (playerPos - currentPos).normalized;
        var body = GetComponent<Rigidbody2D>();
        body.AddForce(delPos * chaseSpeed);
    }
}
