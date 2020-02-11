using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWaterAction : GoapAction {

	Animator anim;

	bool completed = false;
	float startTime = 0;
	public float workDuration = 3; // seconds
	
	public GetWater () {
		addPrecondition ("hasDeliveryWater", false ); 
		addEffect ("hasDeliveryWater", true);
		name = "Get water";
	}

	public void Start()
	{
		anim = this.GetComponent<Animator>();
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
		WaterSpotComponent[] spots = (WaterSpotComponent[])UnityEngine.GameObject.FindObjectsOfType(typeof(WaterSpotComponent));
		WaterSpotComponent closest = null;
		float closestDist = 0;
		
		foreach (WaterSpotComponent spot in spots) {
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
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
		{
			//Debug.Log("Starting: " + name);
			anim.SetBool("getWater", true );
			startTime = Time.time;
		}

		if (Time.time - startTime > workDuration) 
		{
			//Debug.Log("Finished: " + name);
			anim.SetBool("getWater", false );
			//this.GetComponent<Inventory>().waterLevel += 1;//Agent collected water but still needs to deliver it.
			completed = true;
		}
		return true;
	}
	
}
