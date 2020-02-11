using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAction : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float workDuration = 10; // seconds
	Animator anim;
	FishingSpotComponent targetSpot;
	
	void Start()
	{
		anim = this.GetComponent<Animator>();
	}

	public FishAction () {
		addPrecondition ("hasFish", false ); 
		addEffect ("doJob", true);
		name = "Go catch some fish!";
	}
	
	public override void reset ()
	{
		completed = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return completed;
	}
	
	public override bool requiresInRange ()
	{
		return true; 
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{	
		FishingSpotComponent[] spots = (FishingSpotComponent[])UnityEngine.GameObject.FindObjectsOfType(typeof(FishingSpotComponent));
		FishingSpotComponent closest = null;
		float closestDist = 0;
		
		foreach (FishingSpotComponent spot in spots) {
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
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
		{
			anim.SetBool( "fish", true );
			//Debug.Log("Starting: " + name);
			startTime = Time.time;
		}

		if (Time.time - startTime > workDuration) 
		{
			Debug.Log("Finished: " + name);
			//stock = gameObject.FindWithTag("stockpile").GetComponent<Stockpile>().fish += 1;
			completed = true;
			//anim.SetBool( "fish", false );
		}
		return true;
	}
	
}
