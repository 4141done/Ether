using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int hitpoints = 1;//Is This Correct!?!?!?
	public int scoreValue;
	protected GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
				gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}

		CollisionProps otherCollisionProps = other.gameObject.GetComponent<CollisionProps> ();
		CollisionProps thisCollisionProps = gameObject.GetComponent<CollisionProps> ();

		if (otherCollisionProps != null && thisCollisionProps != null) {
			otherCollisionProps.hitpoints -= thisCollisionProps.collisionDamage;
			thisCollisionProps.hitpoints -= otherCollisionProps.collisionDamage;

			if (thisCollisionProps.hitpoints <= 0) {
				ExplodeThis (gameObject);
			}

			if (otherCollisionProps.hitpoints <= 0) {
				if (other.tag == "Player") {
					Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
					gameController.GameOver ();
					ExplodeOther(other.gameObject);
				} else {
					Instantiate (explosion, other.transform.position, other.transform.rotation);
				}
			}

		}

		//if (other.tag != "Player") {  For God Mode
//		if (other.tag == "Player") {
//				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
//			gameController.GameOver();
//			ExplodeOther (other.gameObject);
//		} else {
//			Instantiate (explosion, other.transform.position, other.transform.rotation);
//		}

		//if (other.tag == "Player") {
		//	Instantiate (playerExplosion, other.transform.position, other.transform.rotation);//FROM TUTORIAL
		//}

		//Transform t = gameObject.transform;
		//float growth = 1.02f;
		//t.localScale = new Vector3 (t.localScale.x*growth, t.localScale.y*growth, t.localScale.z*growth);

//		if (--hitpoints <= 0) {
//			ExplodeThis (gameObject);
//		}
	}

	protected virtual void ExplodeOther(GameObject go) {
		Explode (go);
	}

	protected virtual void ExplodeThis(GameObject go) {
		gameController.AddScore (scoreValue);
		Explode (go);
	}

	protected virtual void Explode(GameObject go) {
		Destroy (go);
		Instantiate (explosion, go.transform.position, go.transform.rotation);
	}
}
