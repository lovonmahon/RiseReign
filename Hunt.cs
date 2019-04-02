using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunt : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float workDuration = 3; // seconds
	public Inventory stockpile;
	Inventory inv;
	
	public Hunt () {
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
			stockpile.Meat += 1;			
			completed = true;
		}
		return true;
	}
	
}
