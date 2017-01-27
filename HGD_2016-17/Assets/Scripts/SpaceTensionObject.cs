using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class SpaceTensionObject : MonoBehaviour
{

    public float size;
    public float strength = 5f;
    public float breakingDistance =25f;
    public float reversalDistance = 10f;

    private Vector3 velocity;
    private GameObject player;
    private LineRenderer tether;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        tether = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
           Destroy(gameObject);
        }

        UpdateTether();
    }

    void FixedUpdate()
    {
        player.GetComponent<Rigidbody2D>().AddForce(GetForce(transform.position, player.transform.position));
    }

    Vector2 GetForce(Vector2 source, Vector2 target)
    {
        var distance = Math.Abs(Vector2.Distance(source, target));
        return (source - target).normalized * strength * GetForceScalar(distance);
    }

    float GetForceScalar(float distance)
    {
        if (distance >= breakingDistance)
        {
            Destroy(gameObject);
            return 0f;
        }
        return (distance - reversalDistance);
    }

    void UpdateTether()
    {
        List<Vector3> positions = new List<Vector3>();
        positions.Add(player.transform.position);
        int iterations = 150;
        for (int i = 0; i < iterations; i++)
        {
            var deltaPositions = player.transform.position - transform.position;
            var offSet = new Vector3(-deltaPositions.y, deltaPositions.x, player.transform.position.z);
            //var randomOffsetMultiplier = new UnityEngine.Random();
            float multiplier = UnityEngine.Random.Range(-0.03f, 0.03f);
            offSet *= multiplier;
            positions.Add(player.transform.position - (player.transform.position - transform.position) * i / iterations + offSet);
        }
        positions.Add(transform.position);
        tether.SetVertexCount(positions.Count);
        tether.SetPositions(positions.ToArray());
    }
}
