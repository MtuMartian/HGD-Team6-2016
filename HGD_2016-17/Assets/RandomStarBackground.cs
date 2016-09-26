using UnityEngine;
using System.Collections;

public class RandomStarBackground : MonoBehaviour {

	public float width;
	public float height;
	public int horizontalDivisions;
	public int verticalDivisions;
	public int density;
	public float minStarSize;
	public float maxStarSize;
	public float rotationSpeed;
	public GameObject star;

	// Use this for initialization
	void Start () {
		float divisionWidth = width / horizontalDivisions;
		float divisionHeight = height / verticalDivisions;
		float offsetX = width / 2;
		float offsetY = height / 2;
		for (int i = 0; i < horizontalDivisions; i++) {
			for (int j = 0; j < verticalDivisions; j++) {
				GenerateStarsWithinDivision (transform.position.x - offsetX + i * divisionWidth,
					transform.position.y - offsetY + j * divisionHeight,
					divisionWidth,
					divisionHeight);
			}
		}
		DestroyObject (star);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, rotationSpeed);
	}

	void GenerateStarsWithinDivision(float x, float y, float width, float height) {
		
		for (int i = 0; i < density; i++) {
			float randX = Random.Range (x - width / 2, x + width / 2);
			float randY = Random.Range (y - height / 2, y + height / 2);
			var newStar = Instantiate (star, new Vector3 (randX, randY, 3), Quaternion.identity, transform) as GameObject;
			float randSize = Random.Range (minStarSize, maxStarSize);
			newStar.transform.localScale = new Vector3(randSize, randSize, 1);
		}
	}
}
