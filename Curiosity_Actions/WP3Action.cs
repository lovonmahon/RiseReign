using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  WP3Action : GoapAction {

	//public GameObject waypoint1;
	int currentWP= 0;
	float accuracyWP = 5.0f;
	bool completed = false;
	//float startTime = 0;
	//public float workDuration = 2; // seconds
	
	public PatrolAction () {
		addPrecondition ("atWP2", true); 
		addEffect ("atWP3", true);
		name = "WP3Action";
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
		completed = true
		return true;
	}
	
}
