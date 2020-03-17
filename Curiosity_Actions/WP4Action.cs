using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Waypoint idea borrowed from Holistic3d 'Simple waypoint  pathfinding with the Line of Sight AI'

public class  WP4Action : GoapAction {

	//public GameObject waypoint1;
	int currentWP= 0;
	float accuracyWP = 5.0f;
	bool completed = false;
	//float startTime = 0;
	//public float workDuration = 2; // seconds
	
	public PatrolAction () {
		addPrecondition ("atWP3", true); 
		addEffect ("WP4Action", true);
		name = "WP4Action";
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
