using UnityEngine;
using System.Collections;

public class AlligatorAttackAction : GOAPAction {

	private bool attacked = false;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

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
		Reptile rep = agent.GetComponent<Alligator> ();
		if (rep.stamina >= (cost)) {
			
			rep.animator.Play ("Attack");

			int damage = can.strength;
			if (rep.player.isBlocking) {
				damage -= rep.player.defense;
			}

			rep.player.health -= damage;
			rep.stamina -= cost;

			attacked = true;
			return true;
		} else {
			return false;
		}
	}
}
