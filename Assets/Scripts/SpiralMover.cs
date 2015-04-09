using UnityEngine;
using System.Collections;

public class SpiralMover : MonoBehaviour {

	public float spiralSpeed;
	public float expandSpeed;
	private int rotationDirection;
	public float sprayAngleRange = 0.3f;
	public float sineAmplitude = 0.9f;
	public float sineMagnitude = 0.5f;
	private float timePassed = 0;
	private Vector3 originalPosition;
	private float offset;

	void Start ()
	{
		originalPosition = GetComponent<Rigidbody> ().position;

		offset = Random.value * 2 * Mathf.PI;

		transform.localEulerAngles = new Vector3 (0, offset * 360 / (2 * Mathf.PI) + 90, 0);
	}

	void FixedUpdate() {
		timePassed += Time.deltaTime;

		float x = Mathf.Sin (timePassed*spiralSpeed + offset) * timePassed * expandSpeed;
		float y = Mathf.Cos (timePassed*spiralSpeed + offset) * timePassed * expandSpeed;

		Vector3 newPosition = originalPosition + new Vector3 (x, 0, y);

		GetComponent<Rigidbody> ().position = newPosition;


		float time = Time.deltaTime;
		Vector3 angles = transform.localEulerAngles;

		
		transform.localEulerAngles = new Vector3 (0, spiralSpeed*360/(2*Mathf.PI)*time + angles.y, 0);

	}
}
