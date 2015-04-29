using UnityEngine;
using System.Collections;

public class EngineController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float moveVertical = Input.GetAxis ("Vertical");	

		GameObject[] engines = GameObject.FindGameObjectsWithTag ("Engines");
		foreach (GameObject engine in engines) {
			ParticleSystem ps = engine.GetComponent<ParticleSystem>();

			if (moveVertical > 0) {
				ps.enableEmission = true;
			} else {
				ps.enableEmission = false;
			}
			//ps.transform.position = new Vector3 (position.x, position.y, position.z + (moveVertical * 0.5f));
			//engine.transform.position.z += moveVertical * 0.5;
		}
	}
	

}
