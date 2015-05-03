using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlternatingWeaponController2: MonoBehaviour {
	//Look up renderer for unity

	private float timePassed = 0;
	public float speed;
	public float x;
	public float fireRate;
	private float nextFire;

	public GameObject shot1;
	public GameObject shot2;
	private GameObject mainShot;

	void Start ()
	{
		mainShot = shot1;
	}

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			GameObject thing = (GameObject)Instantiate (mainShot, player.transform.position, new Quaternion (0, 0, 0, 0));
		}
	}

	void FixedUpdate()
	{
		timePassed += Time.deltaTime;
		float y = timePassed * speed;
		float z = Mathf.Sin (x * (y + Mathf.PI / 2));
		
		if (z <= 0) {
			mainShot = shot1;
		} else {
			mainShot = shot2;
		}

//		Instantiate (mainShot, transform.position, new Quaternion (0, 0, 0, 0));
	

	}
	//	Instantiate (weapons[currentWeapon], player.transform.position, new Quaternion(0,0,0,0));
	//	Destroy (gameObject);
}
