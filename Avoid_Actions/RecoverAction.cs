using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RiseReign;

public class RecoverAction : GoapAction {

	float startTime = 0;
    public float healDuration = 5; 
    public Animator anim;
    bool isHealed = false;
    Sight sight;
    Health helt;
	HealingSpotComponent targetSpot; 
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
	    sight = gameObject.GetComponent<Sight>();
	    helt = this.GetComponent<Health>();
    }
    
    public RecoverAction(){
		addPrecondition("isHurt", true);
		addEffect ("doJob", true);
        name = "Recover health";
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
		target = null;
	    isHealed = false;
        startTime = 0;
	}

	public override bool isDone(){
		return isHealed;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent){
     	HealingSpotComponent[] spots = (HealingSpotComponent[])UnityEngine.GameObject.FindObjectsOfType(typeof(HealingSpotComponent));
		HealingSpotComponent closest = null;
		float closestDist = 0;
		
		foreach (HealingSpotComponent spot in spots) {
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

	public override bool perform(GameObject agent){
		if (startTime == 0)
		{
			//Debug.Log("Starting: " + name);
			startTime = Time.time;
		}

		if (Time.time - startTime > healDuration) 
		{
			//anim.SetBool("healingAnimation", true);
			//Debug.Log("Finished: " + name);
			//recoverValue = 100 - helt.currentHealth;
			//helt.currentHealth += recoverValue;
			//windmill.flourLevel -= 5;
            isHealed = true;
		}
		return true;
	}
}
