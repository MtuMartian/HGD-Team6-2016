using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class fluctuate : MonoBehaviour {

	public Image i;
	public int rate = 1000;
	
	// Update is called once per frame
	void Update () {
		Color c = i.color;
		float val = Mathf.Sin (2 * Mathf.PI * Time.deltaTime / rate);
		Debug.Log (val);
		i.color = new Color(c.r, c.g, c.b);
	}
}
