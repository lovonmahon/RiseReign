using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RiseReign;

public class AttackAction : GoapAction {


    public Animator anim;
    bool attacked = false;
    float attackDistance = 3.0f;
    Sight sight;
    NavMeshAgent agent;
    Health helt;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
	    sight = gameObject.GetComponent<Sight>();
	    agent = this.GetComponent<NavMeshAgent>();
	    helt = this.GetComponent<Health>();
	    target = GameObject.FindWithTag("Player");
    }
    
    public AttackAction(){
        addPrecondition("canSeePlayer", true);
		//addEffect ("fight", true);
		addEffect ("doJob", true);
        name = "Attack the player";
	}
    
    //look at the target as long as it's within attack range.
	void Update()
    {
        if( target != null )
		{
			if( Vector3.Distance(transform.position, target.transform.position) <= attackDistance )
			{
				this.transform.LookAt( target.transform );//always look at the target
			}
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
		
		if( target != null )
		{
            if( sight.m_canSeePlayer == true)
			{
				if( helt.health > 30 )
					{
						return true;
					}
			}
		}	
		//return target != null;
        return false;
	}

	public override bool perform(GameObject agent){
			
		if( Vector3.Distance(transform.position, target.transform.position) <= attackDistance )
		{
			this.transform.LookAt(target);
			anim.SetBool( "attack", true );//change to bool in animator.
			attacked = true;
        	return attacked;
		}
		else
		{
			anim.SetBool( "attack", false );//change to bool in animator.
			attacked = false;
        	return attacked;
		}	
	}
}
