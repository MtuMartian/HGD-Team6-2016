using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Audio;
public class OrbSound : MonoBehaviour {
	public AudioSource orb;
	public AudioClip orb_sound;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
				orb.clip = orb_sound;
        if (!GameObject.FindWithTag("Player").GetComponent<PlayerMovementScript>().influencingSpheres.Any()){
			orb.Play();
		}

	}
}
