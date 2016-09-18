using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementScript : MonoBehaviour {

	public float movementForce;
	public float jumpForce;
	public GameObject groundCheck;
	public List<GravitySphereScript> influencingSpheres;
	public List<GameObject> touchingJumpableObjects;
	private GameManagerScript gameManager;

	/* Note: 
	 * Properties are members that function as a variable but allow you to set a custom getter and setter.
	 * This reduces verbosity of code and allows you to pair properties with fields to easily define the
	 * accessors to variables. I will likely be using properties a lot, and be putting them inside
	 * of a 'Properties' region. 
	 * 
	 * If you want to read more about properties I would suggest the following pages:
	 * https://msdn.microsoft.com/en-us/library/x9fsa0sw.aspx
	 * https://msdn.microsoft.com/en-us/library/w86s7x04.aspx
	 */
	#region Properties
	private bool isGrounded 
	{
		get 
		{
			return Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));  
		}
	}
	#endregion

	void Start () {
		influencingSpheres = new List<GravitySphereScript> ();
		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManagerScript> ();
	}

	void FixedUpdate () {
		if (gameManager.isPaused)
			return;
		CheckKeyboardInput ();
	}

	private void CheckKeyboardInput() {
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))
			MoveLeft ();
		
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))
			MoveRight ();

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow))
			Jump();
	}

	private void MoveLeft() {
		if (influencingSpheres.Any ()) {
			var sphere = influencingSpheres.First ();
			Vector3 v3 = (transform.position - sphere.transform.position);
			Vector2 v2 = new Vector2 (v3.x, v3.y).normalized.Rotate (90f);
			GetComponent<Rigidbody2D> ().AddForce (v2 * movementForce);
		}
	}

	private void MoveRight() {
		if (influencingSpheres.Any ()) {
			var sphere = influencingSpheres.First ();
			Vector3 v3 = (transform.position - sphere.transform.position);
			Vector2 v2 = new Vector2 (v3.x, v3.y).normalized.Rotate (-90f);
			GetComponent<Rigidbody2D> ().AddForce (v2 * movementForce);
		}
	}

	private void Jump() {
		if (touchingJumpableObjects.Any ()) {
			var sphere = influencingSpheres.Any() ? influencingSpheres.First().gameObject : touchingJumpableObjects.First ();
			Vector2 v2 = transform.position - sphere.transform.position;
			GetComponent<Rigidbody2D> ().AddForce (v2.normalized * jumpForce);
		}
	}

	void OnCollisionEnter2D (Collision2D obj) {
		if (obj.gameObject.layer == LayerMask.NameToLayer ("GravitySpheres") || obj.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			touchingJumpableObjects.Add (obj.gameObject);
		}
	}

	void OnCollisionExit2D (Collision2D obj) {
		if (obj.gameObject.layer == LayerMask.NameToLayer ("GravitySpheres") || obj.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			touchingJumpableObjects.Remove (obj.gameObject);
		}
	}
		
	void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.gameObject.layer == LayerMask.NameToLayer ("GravitySpheres")) {
			trigger.gameObject.GetComponent<GravitySphereScript> ().activated = true;
			influencingSpheres.Add(trigger.gameObject.GetComponent<GravitySphereScript>());
		}
	}

	void OnTriggerExit2D(Collider2D trigger) {
		if (trigger.gameObject.layer == LayerMask.NameToLayer ("GravitySpheres")) {
			trigger.gameObject.GetComponent<GravitySphereScript> ().activated = false;
			influencingSpheres.Remove (trigger.gameObject.GetComponent<GravitySphereScript> ());
		}
	}
}
