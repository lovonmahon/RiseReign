using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeAction : GoapAction {
//attach the safeHaven component to any hiding spot(currently only 1 supported)
	[SerializeField] float timeBetweenAttack = 1.0f;
    EnemyHealth health;
    Animator anim;
    bool attacked = false;
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
		if(health.currentHealth < 30)
		{
			agent.SetDestination(healingSpot.transform.position);
		}
        return true;
	}

	public override bool perform(GameObject agent)	        
        {
            attacked = true;
			avoid = true;
			return true;
			}        
	}
}
