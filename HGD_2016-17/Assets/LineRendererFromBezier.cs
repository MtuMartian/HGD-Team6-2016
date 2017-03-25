using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LineRendererFromBezier : MonoBehaviour {

    private BezierCurveCollider2D collider;
    private LineRenderer renderer;

	// Use this for initialization
	void Start () {
        collider = GetComponent<BezierCurveCollider2D>();
        var points = collider.getCurvePoints();

        var points3d = new List<Vector3>();
        points.ForEach(point => {
            points3d.Add(new Vector3(point.x, point.y, 0));
        });

        renderer = GetComponent<LineRenderer>();
        renderer.SetVertexCount(points.ToList().Count);
        renderer.SetPositions(points3d.ToArray());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
