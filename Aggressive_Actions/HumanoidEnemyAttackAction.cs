using UnityEngine;
using System.Collections;

public class HumanoidEnemyAttackAction : GOAPAction {

	private bool attacked = false;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	public HumanoidEnemyAttackAction(){
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
		HumanoidEnemy currA = agent.GetComponent<HumanoidEnemy> ();
		currA.stamina -= (500 - cost);

		Animator currAnim = GetComponentInParent<Animator> ();
		//spellAnim.wrapMode = WrapMode.ClampForever; //done in inspector right now
		currAnim.Play("attack");

		attacked = true;
		return attacked;
	}
}
