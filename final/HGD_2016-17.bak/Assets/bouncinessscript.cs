using UnityEngine;
using System.Collections;

public class bouncinessscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var col = GetComponent<Collider2D>();
        col.sharedMaterial = new PhysicsMaterial2D() { bounciness = 2f };
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
