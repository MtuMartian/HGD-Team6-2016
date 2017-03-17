using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SpriteAnimator : MonoBehaviour 
{

    public List<Sprite> sprites;
    public float timePerFrame;

    public bool isCyclic = true;
    private bool isCurrentlyRunning = false;
    private Func<bool> finishedRunningCallback;

    public int id = -1;

    private float timeSinceLastChange = 0f;
    private SpriteRenderer spriteRenderer;

    private int spriteIndex;
    private int SpriteIndex
    {
        get
        {
            var newIndex = spriteIndex % sprites.Count;
            if (newIndex == 0 && spriteIndex != 0)
            {
                isCurrentlyRunning = false;
                if (finishedRunningCallback != null)
                    finishedRunningCallback();
            }
            return newIndex;
        }
        set
        {
            spriteIndex = value;
        }
    }

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update() {
        if (isCyclic || isCurrentlyRunning)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange > timePerFrame)
            {
                spriteRenderer.sprite = sprites[SpriteIndex++];
                timeSinceLastChange %= timePerFrame;
            }
        }
	}

    public void Animate(Func<bool> callback = null)
    {
        isCurrentlyRunning = true;
        finishedRunningCallback = callback;
    }

    public bool IsDone()
    {
        return isCurrentlyRunning;
    }
}
