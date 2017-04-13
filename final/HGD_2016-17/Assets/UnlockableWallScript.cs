using UnityEngine;
using System.Collections;
using System;

public class UnlockableWallScript : MonoBehaviour 
{
    private Collider2D collider;
    private Renderer renderer;
    private GameObject player;
    private KeyScript key;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject == player && player.GetComponent<KeyHolder>().keys.Contains(key))
            Unlock(); 
    }

    public void Unlock()
    {
        AkSoundEngine.PostEvent("KeyGetOpen", this.gameObject);
        player.GetComponent<KeyHolder>().RemoveKey(key);
        Destroy(key.gameObject);
        var animator = GetComponent<SpriteAnimator>();
        Func<bool> callback = () =>
        {
            Destroy(gameObject);
            return true;
        };
        animator.Animate(callback);
    }

    public void SetKey(KeyScript key)
    {
        this.key = key;
    }
}
