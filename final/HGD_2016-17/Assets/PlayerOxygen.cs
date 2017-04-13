using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class PlayerOxygen : MonoBehaviour 
{
    private GameObject player;
    private PlayerMovementScript playerScript;

    private float OxygenPercentage = 100f;
    private Canvas canvas;
    public Image greenBar;
    private bool playingSound = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerMovementScript>();
        canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        Draw();
        if (playerScript.influencingSpheres.Any())
            IncreaseOxygen();
        else
            DecreaseOxygen();
            if (OxygenPercentage < 40f && playingSound == false) {
                playingSound = true;
                AkSoundEngine.PostEvent("OxygenAlarmStart", this.gameObject);
            } 
            if (OxygenPercentage > 40f && playingSound == true) {
                playingSound = false;
                     AkSoundEngine.PostEvent("OxygenAlarmStop", this.gameObject);
            }
                      if (OxygenPercentage <= 0f && playingSound == true) {
                                   AkSoundEngine.PostEvent("OxygenAlarmStop", this.gameObject);
                      }
	}

    void DecreaseOxygen()
    {
        if (OxygenPercentage <= 0f)
        {
            return;
        }
        OxygenPercentage -= 0.1f;
    }

    void IncreaseOxygen()
    {
        if (OxygenPercentage >= 100f)
            OxygenPercentage = 100f;
        else
            OxygenPercentage += 0.5f;
    }

    void Draw()
    {
        greenBar.rectTransform.localScale = new Vector3(OxygenPercentage / 100f, 1, 1);
        if (OxygenPercentage >= 100f)
            canvas.enabled = false;
        else
            canvas.enabled = true;
    }
}
