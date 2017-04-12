using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Audio;

public class MusicLevel : MonoBehaviour {

    public AudioMixer MasterMixer;


    /**
    *Changes the level of the Music group on the MasterMixer
    */
    public void setMudsicLvl(float lvl)
    {

        MasterMixer.SetFloat("musicLvl", lvl);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float current;  //current volume from MasterMixer => Music 
        float freq;     //current cutoff freqeuncy MasterMixer => Music 


        MasterMixer.GetFloat("CutOff_LowPass", out freq); //get current cut off freqeuncy
        MasterMixer.GetFloat("musicLvl", out current);    //get current volcume
        //This test if the player is in or out of the gravity sphere 
        if (!GameObject.FindWithTag("Player").GetComponent<PlayerMovementScript>().influencingSpheres.Any())
        {
            //out of gravity sphere 
            if (current != -8f)
            {
                MasterMixer.SetFloat("LowPass_Resonance", 2f);
                current -= .25f;
                setMudsicLvl(current);
            }
            if (freq > 500)
            {
                freq -= 10;
                MasterMixer.SetFloat("CutOff_LowPass", freq);
            }

        }
        else
        {
            //in gravity sphere 
            if (current != 0f)
            {
                MasterMixer.SetFloat("LowPass_Resonance", 2f);
                current += .25f;
                setMudsicLvl(current);


            }
            if (freq != 5000)
            {
                freq += 10;
                MasterMixer.SetFloat("CutOff_LowPass", freq);
            }
            MasterMixer.SetFloat("LowPass_Resonance", 0f);


        }
    }
}
