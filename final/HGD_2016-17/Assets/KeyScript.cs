using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour 
{

    public GameObject wall;
    private GameObject player;
    private bool isAttached = false;
    private float movementDampening;
    private Vector3 velocity;


	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        var color = GetComponent<SpriteRenderer>().color;
        wall.GetComponent<SpriteRenderer>().color = color;
        wall.GetComponent<UnlockableWallScript>().SetKey(this);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (isAttached)
        {
            UpdatePosition();
        }
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
       
        if (!isAttached && obj.gameObject == player)
        {
            AkSoundEngine.PostEvent("KeyGet", this.gameObject);
            AttachToPlayer();
        }
    }

    void AttachToPlayer()
    {
        isAttached = true;
        var keySet = player.GetComponent<KeyHolder>().keys;
        movementDampening = 0.1f * (keySet.Count + 1);
        keySet.Add(this);
    }

    public void AdjustDampening(float dampening)
    {
        movementDampening = dampening;
    }

    void UpdatePosition()
    {
        // Get the player transform
        var playerTransform = player.GetComponent<Transform>();
        // Get the z position in order to lock transform in place on the z-axis
        var z = transform.position.z;
        // Get the current position
        Vector3 currentPosition = transform.position;
        // Get the difference between the camera's current position and the player's current position
        Vector3 delta = new Vector3(
            playerTransform.position.x - currentPosition.x,
            playerTransform.position.y - currentPosition.y,
            currentPosition.z); // z is fixed
                                // The desired position is equal to the current position + the difference between the object's position
        Vector3 finalPosition = currentPosition + delta;
        // Uses the SmoothDamp method to smoothly move towards the desired final position
        Vector3 smoothMovement = Vector3.SmoothDamp(currentPosition, finalPosition, ref velocity, movementDampening);
        // Update position
        transform.position = new Vector3(smoothMovement.x, smoothMovement.y, z);
    }
}
