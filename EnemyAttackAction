using UnityEngine;
using System.Collections;

public class EnemyAttackAction : GOAPAction {

	private bool attacked = false;

	public EnemyAttackAction(){
		addEffect ("damagePlayer", true);
		cost = 100f;
	}

	public override void reset() {
		attacked = false;
		target = null;
	}

	public override bool isDone(){
		return attacked;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent){
		target = GameObject.Find ("Player");
		return target != null;
	}

	public override bool perform(GameObject agent){
		Canine can = agent.GetComponent<Canine> ();
		if (can.stamina >= (cost)) {
			
			can.animator.Play ("Attack");

			int damage = can.strength;
			if (can.player.isBlocking) {
				damage -= can.player.defense;
			}

			can.player.health -= damage;
			can.stamina -= cost;

			attacked = true;
			return true;
		} else {
			return false;
		}
	}
}
