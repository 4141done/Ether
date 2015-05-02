using UnityEngine;
using System.Collections;

public class PlayerCollisionProps : CollisionProps {
	protected GameController gameController;

	protected override void Start() {
		base.Start ();
		this.gameController = GameObject.FindWithTag ("GameController").GetComponent <GameController>();
	}

	public override void SubtractHitpoints(int hitpoints) {
		this.hitpoints -= hitpoints;
		gameController.SetHP (this.hitpoints, GetMaxHitPoints ());
	}
}
