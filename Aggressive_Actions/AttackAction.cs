using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : GoapAction {

	[SerializeField] float timeBetweenAttack = 1.0f;
    float timeSinceLastAttack = 0;
    public Animator anim;
    bool attacked = false;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
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
		//return target != null;
        return true;
	}

	public override bool perform(GameObject agent){
		//Alligator gator = agent.GetComponent<Alligator> ();
		//gator.stamina -= (500 - cost);
		//Throttle attack
        if(timeSinceLastAttack > timeBetweenAttack)
        {
            anim.SetTrigger("attack");
            timeSinceLastAttack = 0;//reset attack time.
        }        
		attacked = true;
		return attacked;
        return true;
	}
}
