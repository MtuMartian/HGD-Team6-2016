using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	public float movementForce;
	public float jumpForce;
	public GameObject groundCheck;

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

	void Start () {}

	void FixedUpdate () {
		CheckKeyboardInput ();
	}

	private void CheckKeyboardInput() {
		if (Input.GetKey (KeyCode.A))
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-1 * movementForce, 0));
		
		if (Input.GetKey (KeyCode.D))
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(movementForce, 0));

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded)
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
	}
}
