using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public GameObject shot;
	public float fireRate;
	public Boundary boundary; 
	public string defaultWeaponName;

	private float nextFire;
	private  GUIText weaponText;

	private Object[] weapons;

	private int currentWeapon = 0;
	GameObject weapon;

	void Start () {
		weapons = Resources.LoadAll ("Prefabs/Weapons");
		for (int i = 0; i < weapons.Length; i++) {
			if (((GameObject)weapons[i]).GetComponent<ObjectProps> ().weaponName == defaultWeaponName) {
				currentWeapon = i;
				break;
			}
		}
	}


	void Update ()
	{
		if (Input.GetButtonUp ("Fire3")) {
			if (currentWeapon == weapons.Length - 1) {
				currentWeapon = 0;
			} else {
				currentWeapon++;
			}
		}

		weapon = (GameObject) weapons [currentWeapon];
		string weaponName = weapon.GetComponent<ObjectProps> ().weaponName;
		weaponText = GameObject.FindGameObjectWithTag ("WeaponDisplay").GetComponent<GUIText>();
		weaponText.text = "Weapon: " + weaponName;

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject player = GameObject.FindGameObjectWithTag("Player");

			Instantiate (weapons[currentWeapon], player.transform.position, new Quaternion(0,0,0,0));
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
