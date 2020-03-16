using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedLivestockAction : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float workDuration = 10; // seconds
	
	public PickupFlour () {
		addPrecondition ("hasHay", true); 
		addEffect ("feedLivestock", true);
		name = "Feed Livestock";
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
		return true;
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
			this.GetComponent<Inventory>().HayLevel -= 5;
			completed = true;
		}
		return true;
	}
	
}
