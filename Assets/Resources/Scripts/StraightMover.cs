using UnityEngine;
using System.Collections;

public class StraightMover : MonoBehaviour {
	
	public float speed;
	public int angle = 0;
	
	protected virtual void Start ()
	{
		float angleRadians = Mathf.Deg2Rad * (-angle + 90f);
		Vector3 shotDirection = new Vector3 (Mathf.Cos (angleRadians), 0, Mathf.Sin (angleRadians));
		GetComponent<Rigidbody>().velocity = shotDirection * speed;
	}

}
