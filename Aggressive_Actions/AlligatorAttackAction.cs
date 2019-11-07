using UnityEngine;
using System.Collections;

public class AlligatorAttackAction : GoapAction {

	private bool attacked = false;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	public AlligatorAttackAction(){
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
		target = GameObject.FindWithTag("Player");
		return target != null;
	}

	public override bool perform(GameObject agent){
		Alligator gator = agent.GetComponent<Alligator> ();
		gator.stamina -= (500 - cost);

		Animator currAnim = GetComponentInParent<Animator> ();
		
		currAnim.Play("attack");

		attacked = true;
		return attacked;
	}
}
