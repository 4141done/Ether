using UnityEngine;
using System.Collections;

public class CollisionProps : MonoBehaviour {
	public int hitpoints;
	public int mass;
	public int collisionDamage;
	protected int maxHitpoints;

	protected virtual void Start() {
		maxHitpoints = hitpoints;
	}

	public int GetMaxHitPoints() {
		return maxHitpoints;
	}

	public virtual void SubtractHitpoints(int hitpoints) {
		this.hitpoints -= hitpoints;
	}

}

