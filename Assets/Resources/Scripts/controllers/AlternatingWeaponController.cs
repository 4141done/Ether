using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlternatingWeaponController: MonoBehaviour {

	public float speed = 10;
	public GameObject shot;
	public float fireRate;
	public Boundary boundary; 
	public string defaultWeaponName;

	private float nextFire;
	private  GUIText weaponText;

	private Object[] weapons;

	//private int currentWeapon = 0;
	GameObject weapon;

//	void Update ()
//	{
//		if (Input.GetButtonUp ("Change Weapon")) {
//			if (currentWeapon == weapons.Length - 1) {
//				currentWeapon = 0;
//			} else {
//				currentWeapon++;
//			}
//		}
//
//		weapon = (GameObject) weapons [currentWeapon];
//		string weaponName = weapon.GetComponent<ObjectProps> ().weaponName;
//		weaponText = GameObject.FindGameObjectWithTag ("WeaponDisplay").GetComponent<GUIText>();
//		weaponText.text = "Weapon: " + weaponName;
//
//		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
//			nextFire = Time.time + fireRate;
//			GameObject player = GameObject.FindGameObjectWithTag("Player");
//
//			Instantiate (weapons[currentWeapon], player.transform.position, new Quaternion(0,0,0,0));
//			GetComponent<AudioSource>().Play();//plays sound associated with object
//		}
//	}

	void FixedUpdate()
	{
	//	Instantiate (weapons[currentWeapon], player.transform.position, new Quaternion(0,0,0,0));

	}
}
