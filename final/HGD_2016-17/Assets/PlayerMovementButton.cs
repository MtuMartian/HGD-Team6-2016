using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

	public delegate void UpdateCall();
	private bool isDown = false;
	public UpdateCall handler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isDown)
			handler();
	}

	public void OnPointerDown(PointerEventData data)
	{
		isDown = true;
	}

	public void OnPointerUp(PointerEventData data)
	{
		isDown = false;
	}

	public void OnPointerExit(PointerEventData data)
	{
		isDown = false;
	}
}
