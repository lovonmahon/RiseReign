using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : GoapAction {


    public Animator anim;
    bool attacked = false;
    Sight sight;
    NavmeshAgent agent;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
	sight = gameObject.GetComponent<Sight>();
	agent = this.GetComponent<NAvmeshAgent>();
    }
    
    public AttackAction(){
        addPrecondition("damagePlayer", false);
		addEffect ("doJob", true);
		//cost = 1.0f;
        name = "AttackAction";
	}

	void Update()
    {
        	if(target != null)
		{
			transform.LootAt(target);//always look at the target
			timeSinceLastAttack += Time.deltaTime; // checks when last attack occurred.
		}
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
		if( sight.m_canSeePlayer == true)
		{
			if( target != null )
			{
				return true;
			}	
		}
		//return target != null;
        	return false;
	}

	public override bool perform(GameObject agent){
		anim.SetTrigger("attack");
		if ( target.isBlocking )
		{
			transform.RotateAround( sight.dirToTarget, Vector3.up, 90f * Time.deltaTime );//points to the targets vector 3 location to rotate around.
		}	
		//Alligator gator = agent.GetComponent<Alligator> ();
		//gator.stamina -= (500 - cost);
              
		attacked = true;
         	return true;
	}
}
