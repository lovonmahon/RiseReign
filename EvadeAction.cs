using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeAction : GoapAction {
//attach the safeHaven component to any hiding spot(currently only 1 supported)
	[SerializeField] float timeBetweenAttack = 1.0f;
    	EnemyHealth health;
    	Animator anim;
    	bool isHiding = false;
	bool avoid = false;
	Transform healingSpot;
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponentInChildren<Animator>();
		health = this.GetComponent<EnemyHealth>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
		health = this.GetComponent<EnemyHealth>();
		healingSpot = gameObject.GetComponent<safeHavenComponent>();
    }
    
    public EvadeAction(){
        addPrecondition("runAway", false);
		addEffect ("hasHealth", (health.currentHealth < 30));
		//cost = 1.0f;
        name = "EvadeAction";
	}

	void Update()
    {
        	if(target != null)
		{
			//transform.LootAt(target);//always look at the target
			if(avoid)
			{
				Vector3 targetCheck = transform.position - target.position;//check distance to the target
				Vector3 goToPosition = transform.position + targetCheck;//Calculate flee distance to move away from target threat.
				agent.SetDestination(goToPosition);//Run!
			}
		}
    }
    
    public override void reset() {
		avoid = false;
		target = null;
	}

	public override bool isDone(){
		return avoid;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent){
		target = GameObject.FindWithTag("Player");
		return target != null;
		if(health.currentHealth < 30)
		{
			agent.SetDestination(healingSpot.transform.position);
		}
        return true;
	}

	public override bool perform(GameObject agent)	        
        {
            isHiding = true;
	    avoid = true;
	    return true;
	}        
	
}
