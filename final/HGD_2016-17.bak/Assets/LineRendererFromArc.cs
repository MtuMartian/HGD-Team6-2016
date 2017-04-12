using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LineRendererFromArc : MonoBehaviour {
	private ArcCollider2D collider;
	private LineRenderer renderer;

	void Start () {
		collider = GetComponent<ArcCollider2D>();
		var points = collider.getPoints(new Vector2(transform.position.x, transform.position.y)).ToList();

		var points3D = new List<Vector3>();
		points.ForEach(point => {
			points3D.Add(new Vector3(point.x, point.y, 0));
		});

		renderer = GetComponent<LineRenderer>();
		renderer.SetVertexCount(points.ToList().Count);
		renderer.SetPositions(points3D.ToArray());
	}
}

