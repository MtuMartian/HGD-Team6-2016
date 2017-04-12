using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour
{
    public float parralax = 2f;

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Vector2 offset = mr.material.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;
        mr.material.mainTextureOffset = offset;
    }
}