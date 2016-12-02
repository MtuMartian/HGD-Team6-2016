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
        // Divides the area of the background into rectangular divisions
		float divisionWidth = width / horizontalDivisions;
		float divisionHeight = height / verticalDivisions;
		float offsetX = width / 2;
		float offsetY = height / 2;
        // Generates stars within each division. If we choose to make the stars psuedo random instead
        // of fully random, we can modify the GenerateStarsWithinDivision method
		for (int i = 0; i < horizontalDivisions; i++) {
			for (int j = 0; j < verticalDivisions; j++) {
				GenerateStarsWithinDivision (transform.position.x - offsetX + i * divisionWidth,
					transform.position.y - offsetY + j * divisionHeight,
					divisionWidth,
					divisionHeight);
			}
		}
        // The star gameobject is used to generate all of the other stars. The original star can be deleted so
        // that there is not always the same star in the center of the background
		DestroyObject (star);
	}
	
	// Update is called once per frame
	void Update () {
        // If desired, the star background will rotate. If not, set rotation speed to be 0
		transform.Rotate (0, 0, rotationSpeed);
	}

	void GenerateStarsWithinDivision(float x, float y, float width, float height) {
		// Instantiate stars within the partition
		for (int i = 0; i < density; i++) {
			float randX = Random.Range (x - width / 2, x + width / 2);
			float randY = Random.Range (y - height / 2, y + height / 2);
			var newStar = Instantiate (star, new Vector3 (randX, randY, 3), Quaternion.identity, transform) as GameObject;
			float randSize = Random.Range (minStarSize, maxStarSize);
			newStar.transform.localScale = new Vector3(randSize, randSize, 1);
		}
	}
}
