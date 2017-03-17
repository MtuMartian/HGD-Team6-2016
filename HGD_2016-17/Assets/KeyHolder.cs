using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyHolder : MonoBehaviour 
{
    public List<KeyScript> keys;
	// Use this for initialization
	void Start () {
        keys = new List<KeyScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RemoveKey(KeyScript key)
    {
        Debug.Log("KEY REMOVED");
        keys.Remove(key);
        for (int i = 0; i < keys.Count; i++)
        {
            keys[i].AdjustDampening(0.1f * (i + 1));
        }
    }
}
