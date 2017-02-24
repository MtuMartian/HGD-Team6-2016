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
            AudioSource one = gos[0].GetComponent<AudioSource>();
            one.volume = .5f;
            AudioSource two = gos[1].GetComponent<AudioSource>();
            two.volume = .5f;
        }
    }
}
