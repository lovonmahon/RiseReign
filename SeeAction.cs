using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeAction : GoapAction {

		//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	
  
  
  void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    
    public SeeAction(){
        addPrecondition("damagePlayer", false);
		addEffect ("doJob", true);
		//cost = 1.0f;
        name = "SeeAction";
	}

	void Update()
    {
        	RaycastHit hit;

          float theDist;
          Vector3 forwardDist = transform.position, transform.TransformDirection(Vector3.forward) * 20;
          Vector3 leftDist = transform.position, transform.TransformDirection(Vector3.left) * 20;
          Vector3 rightdDist = transform.position, transform.TransformDirection(Vector3.right) * 20;
          if(Physics.Raycast(transform.position, (forwardDist), out hit)
{
	if(hit.collider.tag == "player" && health > 30)
	{
		theDist = hit.distance;
	}
	
}

if(Physics.Raycast(transform.position, (leftDist), out hit)
{
	if(hit.collider.tag == "player" && health > 30)
	{
		theDist = hit.distance;
	}
}

if(Physics.Raycast(transform.position, (rightdDist), out hit)
{
	if(hit.collider.tag == "player" && health > 30)
	{
		theDist = hit.distance;
	}
}

agent.SetDestination(theDist);

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
