using UnityEngine;
using System.Collections;

public class AttatchEnemySoundControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
         GameObject[] gos  = GameObject.FindGameObjectsWithTag("AttatchEnemy");
        if (gos.Length >= 2)
        {
            Debug.Log("there is more than 2 or equal to 2");
            string stateone = gos[0].GetComponent<AttachEnemyAI>().WhatState();
            AudioSource one = gos[0].GetComponent<AudioSource>();
            Debug.Log(stateone);
            if (stateone =="Attack" | stateone == "Alert" )
            {
                Debug.Log("This is the changing the audio source");
                one.volume = .3f;
            } else
            {
                one.volume = 1f;
            }
            string statetwo = gos[1].GetComponent<AttachEnemyAI>().WhatState();
            AudioSource two = gos[1].GetComponent<AudioSource>();
            if (statetwo == "Attack"  | statetwo == "Alert")
            {
                two.volume = .3f;
            } else
            {
                two.volume = 1f;
            }
        }
    }
}
