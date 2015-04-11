﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public Boundary boundary;
	
	private float nextFire;

	private GameObject[] weapons;
	private int currentWeapon = 0; 

	void Start () {
//		weapons = Resources.LoadAll()
//		print (weapons.Length);
	}

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();//plays sound associated with object
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");	
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		transform.localEulerAngles = new Vector3 (20*moveVertical, 0, -80*moveHorizontal);

		Rigidbody rigidbody = GetComponent<Rigidbody> ();

		rigidbody.velocity = movement*speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);



		        


	}
}