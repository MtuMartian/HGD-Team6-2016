using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteAnimator : MonoBehaviour 
{

    public List<Sprite> sprites;
    public float timePerFrame;

    public int id = -1;

    private float timeSinceLastChange = 0f;
    private SpriteRenderer spriteRenderer;

    private int spriteIndex;
    private int SpriteIndex
    {
        get
        {
            Debug.Log(spriteIndex + " % " + sprites.Count);
            return spriteIndex % sprites.Count;
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
	void Update () {
        timeSinceLastChange += Time.deltaTime;
	    if (timeSinceLastChange > timePerFrame)
        {
            spriteRenderer.sprite = sprites[SpriteIndex++];
            timeSinceLastChange %= timePerFrame;
        }
	}
}
