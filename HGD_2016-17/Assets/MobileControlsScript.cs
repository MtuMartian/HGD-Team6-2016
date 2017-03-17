using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileControlsScript : MonoBehaviour 
{
	public Button leftBtn;
	public Button rightBtn;
	private PlayerMovementScript player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<PlayerMovementScript> ();
		var lBtnScript = leftBtn.GetComponent<PlayerMovementButton> ();
		var rBtnScript = rightBtn.GetComponent<PlayerMovementButton> ();

		lBtnScript.handler = () => { player.MoveLeft(); };
		rBtnScript.handler = () => { player.MoveRight(); };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
