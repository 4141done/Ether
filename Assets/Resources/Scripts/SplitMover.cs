using UnityEngine;
using System.Collections;

public class SplitMover : StraightMover {

	public GameObject splitShot;
	public int spawnCount = 3;

	protected override void Start ()
	{
		base.Start ();
	}

	void Update() {
		if (Input.GetButton ("Fire2")) {
			//GameObject splitShot = (GameObject) Resources.Load("Prefabs/Weapons/SprayBolt");

			//splitShot.GetComponent<Rigidbody>().AddExplosionForce(.5f, transform.position, .5f);

			int angleIncrement = 360 / spawnCount;

			for (int i = 0; i < spawnCount; i++) {

				float angleRadians = Mathf.Deg2Rad * (-angleIncrement * i + 90f);
				var positionOffset = new Vector3 (Mathf.Cos (angleRadians), 0, Mathf.Sin (angleRadians))*.2f;

				GameObject thing = (GameObject) Instantiate (splitShot, transform.position + positionOffset, new Quaternion(0,0,0,0));


				thing.GetComponent<Rigidbody>().AddExplosionForce(100f, transform.position, 100f);

			}

			Destroy (gameObject);
		}
	}

}
