using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RiseReign;

public class EvadeAction : GoapAction {

	//public GameObject place;
    public Animator anim;
    bool isHiding = false;
    bool avoid = false;
    Sight sight;
    LookAt look;
	HidingSpotComponent targetSpot; 
	NavMeshAgent agent;
	float startTime = 0;	
	public float hideDuration = 10; // seconds

	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
	    sight = gameObject.GetComponent<Sight>();
		agent = this.GetComponent<NavMeshAgent>();
		look = 	this.GetComponent<LookAt>();
    }
    
    public EvadeAction(){
		addPrecondition("canSeePlayer", true);
		//addPrecondition ("flee", false);//Is this still needed?
		addEffect ("doJob", true);
        name = "Evade";
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
		avoid = false;
		target = null;
	    isHiding = false;
	    startTime = 0;
	}

	public override bool isDone(){
		return avoid;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent){
     	HidingSpotComponent[] spots = (HidingSpotComponent[])UnityEngine.GameObject.FindObjectsOfType(typeof(HidingSpotComponent));
		HidingSpotComponent closest = null;
		float closestDist = 0;
		
		foreach (HidingSpotComponent spot in spots) {
			if (closest == null) {
				// first one, so choose it for now
				closest = spot;
				closestDist = (spot.gameObject.transform.position - agent.transform.position).magnitude;
			} else {
				// is this one closer than the last?
				float dist = (spot.gameObject.transform.position - agent.transform.position).magnitude;
				if (dist < closestDist) {
					// we found a closer one, use it
					closest = spot;
					closestDist = dist;
				}
			}
		}
		if (closest == null)
			return false;

		targetSpot = closest;
		target = targetSpot.gameObject;
		
		return closest != null;
    }

	public override bool perform(GameObject agent)
	{
		if (startTime == 0)
		{
			anim.SetBool( "hidingAnimation", true );
			look.target = gameObject.FindWithTag("Player").transform;//needs testing.
			startTime = Time.time;
		}

		if (Time.time - startTime > hideDuration) 
		{
			completed = true;
			anim.SetBool( "hidingAnimation", false );
			isHiding = true;
	    	avoid = true;
		}
		return true;
	}
}
