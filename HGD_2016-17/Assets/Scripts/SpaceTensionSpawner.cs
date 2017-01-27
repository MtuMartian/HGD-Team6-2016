using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;


public class SpaceTensionSpawner : MonoBehaviour
{
    public float size;
    public float strength = 25f;
    public float breakingDistance = 25f;
    public float reversalDistance = 10f;

    public GameObject TetherPrefab;

    private PlayerMovementScript player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovementScript>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))// && !player.influencingSpheres.Any())
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject tensionObject = Instantiate(TetherPrefab, position, Quaternion.identity) as GameObject;
            var tensionScript = tensionObject.GetComponent<SpaceTensionObject>();
            tensionScript.strength = strength;
            tensionScript.breakingDistance = breakingDistance;
            tensionScript.reversalDistance = reversalDistance;
            /*var tensionObject = new GameObject();
            tensionObject.transform.position = position;
            tensionObject.AddComponent<SpaceTensionObject>();
            tensionObject.AddComponent<ParticleSystem>();*/
        }
    }

}
