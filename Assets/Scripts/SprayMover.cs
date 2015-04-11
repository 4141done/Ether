using UnityEngine;
using System.Collections;

public class SprayMover : MonoBehaviour {

	public float speed;
	private int rotationDirection;
	public float sprayAngleRange = 0.3f;

	void Start ()
	{
		float sprayAngle = (Random.value * 2 - 1) * sprayAngleRange;
		Vector3 shootingDirection = new Vector3 (sprayAngle, 0, 1);
		GetComponent<Rigidbody>().velocity = shootingDirection * speed;
		this.rotationDirection = (Random.value - 0.5f > 0) ? 1 : -1;
	}

	void FixedUpdate() {
		float time = Time.deltaTime;
		Vector3 angles = transform.localEulerAngles;

		transform.localEulerAngles = new Vector3 (0, rotationDirection*360*time + angles.y, 0);
	}
}
