using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private GameObject player;
    private GameObject sentry;
    private bool activated = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Init(GameObject sentry)
    {
        this.sentry = sentry;
        transform.position = sentry.transform.position;
        if (player == null)
            player = GameObject.FindWithTag("Player");
        var tempRot = transform.rotation;

        transform.LookAt(player.transform);
        transform.rotation = new Quaternion(tempRot.x, tempRot.y, transform.rotation.z, tempRot.w);
        GetComponent<Rigidbody2D>().velocity = (player.transform.position - sentry.transform.position).normalized * 40f;
        activated = true;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject != sentry && activated && !obj.isTrigger)
            Destroy(this.gameObject);
    }
}
