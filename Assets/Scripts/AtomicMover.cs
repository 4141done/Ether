using UnityEngine;
using System.Collections;

public class AtomicMover : MonoBehaviour {

	public float speed;
	private int rotationDirection;
	public float sprayAngleRange = 0.3f;
	public float sineAmplitude = 0.9f;
	public float sineMagnitude = 0.5f;
	private float timePassed = 0;
	private Vector3 originalPosition;

	void Start ()
	{
		originalPosition = GetComponent<Rigidbody> ().position;
//		float sprayAngle = (Random.value * 2 - 1) * sprayAngleRange;
//		Vector3 shootingDirection = new Vector3 (sprayAngle, 0, 1);
//		GetComponent<Rigidbody>().velocity = shootingDirection * speed;
//		this.rotationDirection = (Random.value - 0.5f > 0) ? 1 : -1;
	}

	void FixedUpdate() {
		timePassed += Time.deltaTime;
		float r = timePassed * speed;


		float x = Mathf.Sin (r) * timePassed * speed;
		float y = Mathf.Cos (r) * timePassed * speed;

		Vector3 newPosition = originalPosition + new Vector3 (x, 0, y);

		GetComponent<Rigidbody> ().position = newPosition;

//		Vector3 angles = transform.localEulerAngles;
//
//		Vector3 shootingDirection = new Vector3 (0, rotationDirection * 360 * time + GetComponent<Rigidbody> ().velocity.y, 0);
//		GetComponent<Rigidbody>().velocity = shootingDirection * speed;

		//transform.localEulerAngles = new Vector3 (0, rotationDirection*360*time + angles.y, 0);
	}
}
