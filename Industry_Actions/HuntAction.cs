using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach HuntingSpotComponent script to spawned animals.  See how performance is.
public class HuntAction : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float workDuration = 3; // seconds
	public Stockpile stockpile;
	Inventory inv;
	HuntingSpotComponent targetSpot;
	
	public HuntAction () {
		addPrecondition ("hasMeat", false); 
		addEffect ("hasMeat", true);
		name = "Hunt";
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
		HuntingSpotComponent[] spots = (HuntingSpotComponent[])UnityEngine.GameObject.FindObjectsOfType(typeof(HuntingSpotComponent));
		HuntingSpotComponent closest = null;
		float closestDist = 0;
		
		foreach (HuntingSpotComponent spot in spots) {
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
			Debug.Log("Starting: " + name);
			startTime = Time.time;
		}

		if (Time.time - startTime > workDuration) 
		{
			Debug.Log("Finished: " + name);
			//stockpile.Meat += 1;			
			completed = true;
		}
		return true;
	}
	
}
