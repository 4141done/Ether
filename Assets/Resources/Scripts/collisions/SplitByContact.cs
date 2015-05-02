using UnityEngine;
using System.Collections;

public class SplitByContact : DestroyByContact {
	public GameObject splitObject;

	protected override void ExplodeThis(GameObject go) {
		Transform t = go.transform;
		Instantiate (splitObject, t.position + new Vector3(1, 0, 0), t.rotation);
		Instantiate (splitObject, t.position - new Vector3(1, 0, 0), t.rotation);
		Explode (gameObject);
	}
}
