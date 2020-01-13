using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RiseReign;

public class AttackAction : GoapAction {


    public Animator anim;
    bool attacked = false;
    Sight sight;
    NavMeshAgent agent;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
	    sight = gameObject.GetComponent<Sight>();
	    agent = this.GetComponent<NavMeshAgent>();
    }
    
    public AttackAction(){
        addPrecondition("canSeePlayer", true);
		addEffect ("fight", true);
		//addEffect ("doJob", true);
        name = "Attack the player if I'm healthy enough";
	}
    //Deal with look at later.
	/*void Update()
    {
        	if(target != null)
		{
			this.transform.LookAt(target);//always look at the target
			//timeSinceLastAttack += Time.deltaTime; // checks when last attack occurred.
		}
    }*/
    
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
			if( target != null )
			{
                if( sight.m_canSeePlayer == true)
				{
					return true;
				}
			}	
        	return false;
	}

	public override bool perform(GameObject agent){
		anim.SetBool("farm", true);
		Debug.Log("Attacking");
		//anim.SetTrigger("attack");
		/*if ( target.isBlocking )
		{
			transform.RotateAround( sight.dirToTarget, Vector3.up, 90f * Time.deltaTime );//points to the targets vector 3 location to rotate around.
		}*/ //deal with blocking later.	
              
		attacked = true;
        return true;
	}
}
