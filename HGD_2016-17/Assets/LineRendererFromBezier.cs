using UnityEngine;
using System.Collections;
using System.Linq;

public class LineRendererFromBezier : MonoBehaviour {

    private BezierCollider2D collider;
    private LineRenderer renderer;

	// Use this for initialization
	void Start () {
        collider = GetComponent<BezierCollider2D>();
        var points = collider.calculate3DPoints();

        renderer = GetComponent<LineRenderer>();
        renderer.SetVertexCount(points.ToList().Count);
        renderer.SetPositions(points);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
