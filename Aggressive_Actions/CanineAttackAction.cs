using UnityEngine;
using System.Collections;

public class CanineAttackAction : GOAPAction {

	private bool attacked = false;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	public CanineAttackAction(){
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
		Canine currA = agent.GetComponent<Canine> ();
		currA.stamina -= (500 - cost);

		Animator currAnim = GetComponentInParent<Animator> ();
		//spellAnim.wrapMode = WrapMode.ClampForever; //done in inspector right now
		currAnim.Play("attack");

		attacked = true;
		return attacked;
	}
}
