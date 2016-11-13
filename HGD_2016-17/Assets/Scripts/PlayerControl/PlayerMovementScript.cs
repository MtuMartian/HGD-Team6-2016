using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementScript : MonoBehaviour {

	public float movementForce = 48f;
    public float maxSpeed = 20f;
	public float jumpForce = 1400f;
	public GameObject groundCheck;
	public List<GravitySphereScript> influencingSpheres;
	public List<GameObject> touchingJumpableObjects;
	private GameManagerScript gameManager;
	private float lastJump = 0f;
	private float previousDrag;

    public Dictionary<PickupScript.PickupType, int> pickupDictionary;

    #region Properties
    private bool isGrounded 
	{
		get 
		{
			return Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"))
				|| Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("GravitySpheres"));  
		}
	}
    public GravitySphereScript influencingSphere
    {
        get //TODO: Update our method for finding the influencing sphere
        {
            return influencingSpheres.Any() ? influencingSpheres.First() : null;
        }
    }
	#endregion

	void Start () {
		influencingSpheres = new List<GravitySphereScript> ();
		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManagerScript> ();
		previousDrag = GetComponent<Rigidbody2D> ().drag;
        pickupDictionary = new Dictionary<PickupScript.PickupType, int> ();
        foreach (PickupScript.PickupType type in Enum.GetValues(typeof(PickupScript.PickupType)))
            pickupDictionary.Add(type, 0);
	}

	void FixedUpdate () {
		if (gameManager.isPaused)
			return;
		CheckKeyboardInput ();
	}

	private void CheckKeyboardInput() {
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey("a"))
			MoveLeft ();
		
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))
			MoveRight ();

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow))
			Jump ();

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            UsePickup(PickupScript.PickupType.INCREASE);
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            UsePickup(PickupScript.PickupType.DECREASE);
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            UsePickup(PickupScript.PickupType.REVERSE);
    }

	private void MoveLeft() {
		if (influencingSpheres.Any ()) {
			var sphere = influencingSpheres.First ();
			Vector3 v3 = (transform.position - sphere.transform.position);
			Vector2 v2 = new Vector2 (v3.x, v3.y).normalized.Rotate (90f);
            Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
            if (Vector3.Project(currentVelocity, v2).magnitude <= maxSpeed) {
                GetComponent<Rigidbody2D>().AddForce(v2 * movementForce);
                //GetComponent<Rigidbody2D>().AddTorque(20f); !! We should consider adding torque as well to make the movement more fluid !!
            }
		}
	}

	private void MoveRight() {
		if (influencingSpheres.Any ()) {
			var sphere = influencingSpheres.First ();
			Vector3 v3 = (transform.position - sphere.transform.position);
			Vector2 v2 = new Vector2 (v3.x, v3.y).normalized.Rotate (-90f);
            Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
            if (Vector3.Project(currentVelocity, v2).magnitude <= maxSpeed) {
                GetComponent<Rigidbody2D>().AddForce(v2 * movementForce);
                //GetComponent<Rigidbody2D>().AddTorque(-20f);
            }
        }
	}

	private void Jump() {
		float curTime = Time.time;
		if (curTime - lastJump < 0.1f)
			return;
		if (isGrounded) {
			var sphere = influencingSpheres.Any() ? influencingSpheres.First().gameObject : touchingJumpableObjects.First ();
			Vector2 v2 = transform.position - sphere.transform.position;
			GetComponent<Rigidbody2D> ().AddForce (v2.normalized * jumpForce);
			lastJump = curTime;
		}
	}

    public void CollectPickup(PickupScript pickUp) {
        pickupDictionary[pickUp.type] = pickupDictionary[pickUp.type] + 1;
    }

    public void UsePickup(PickupScript.PickupType type) {
        switch (type)
        {
            case PickupScript.PickupType.INCREASE:
                if (influencingSphere != null && pickupDictionary[type] > 0) {
                    influencingSphere.strength += 1000;
                    pickupDictionary[type] -= 1;
                }
                break;
            case PickupScript.PickupType.DECREASE:
                if (influencingSphere != null && pickupDictionary[type] > 0) {
                    influencingSphere.strength -= 1000;
                    pickupDictionary[type] -= 1;
                }
                break;
            case PickupScript.PickupType.REVERSE:
                if (influencingSphere != null && pickupDictionary[type] > 0) {
                    influencingSphere.strength *= -1;
                    pickupDictionary[type] -= 1;
                }
                break;
            default:
                break;
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
        // When the player enters the radius of influence of a gravity sphere, add that
        // sphere to the collection of influencing spheres
		if (trigger.gameObject.layer == LayerMask.NameToLayer ("GravitySpheres")) {
			trigger.gameObject.GetComponent<GravitySphereScript> ().activated = true;
			influencingSpheres.Add(trigger.gameObject.GetComponent<GravitySphereScript>());
            // Return the player's drag
			GetComponent<Rigidbody2D> ().drag = previousDrag;
		}
	}

	void OnTriggerExit2D(Collider2D trigger) {
        // When the player exits the radius of influence of a gravity sphere, remove that
        // sphere from the collection of influencing spheres
        if (trigger.gameObject.layer == LayerMask.NameToLayer ("GravitySpheres")) {
			trigger.gameObject.GetComponent<GravitySphereScript> ().activated = false;
			influencingSpheres.Remove (trigger.gameObject.GetComponent<GravitySphereScript> ());
            // If the player is no longer within the radius of influence of any spheres, set its drag to be zero
			if (!influencingSpheres.Any ()) {
				previousDrag = GetComponent<Rigidbody2D> ().drag;
				GetComponent<Rigidbody2D> ().drag = 0f;
			}
		}
	}
}
