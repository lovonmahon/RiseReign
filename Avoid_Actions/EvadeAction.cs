using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvadeAction : GoapAction {
//attach the HidingSpotComponent to any hiding spot
    Transform hidingSpotTransform;
    EnemyHealth health;
    Animator anim;
    bool avoid = false;
    //bool injured = false;//handle later
    //float threatDistance = 20.0f;
    HidingSpotComponent targetSpot; // where we hide
	
	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
		//health = this.GetComponent<EnemyHealth>();//handle this later
		hidingSpotTransform = target.transform;
    }
    
    public EvadeAction()
    {
		addPrecondition("canSeePlayer", true );    	
	    addEffect ("runAway", true );
        name = "EvadeAction";
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

	public override bool checkProceduralPrecondition(GameObject agent)
    {
	   // find the nearest hiding spot 
		HidingSpotComponent[] spots = GameObject.FindObjectsOfType<HidingSpotComponent>();
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
		
		targetSpot = closest;
		target = targetSpot.gameObject;

		if (closest != null)
		{
			return true;
			MoveToLocation( target );
			//agent.SetDestination(target);//Trying to use the MoveToLocation() to handle movement below..
		}

		return false;
    }

	public override bool perform(GameObject agent)	        
    {
        anim.SetTrigger("hidingAnimation");
	    avoid = true;
	    return true;
	}

	public void MoveToLocation( Vector3 targetPoint )
	{
		agent.destination = targetPoint;
		agent.isStopped = false;
	}        
	
}
