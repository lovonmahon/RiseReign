using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Waypoint idea borrowed from Holistic3d 'Simple waypoint  pathfinding with the Line of Sight AI'

public class  PatrolAction : GoapAction {

	public GameObject[] waypoints;
	int currentWP= 0;
	float accuracyWP = 5.pf;
	bool completed = false;
	//float startTime = 0;
	//public float workDuration = 2; // seconds
	
	public PatrolAction () {
		addPrecondition ("canSeePlayer", false); 
		addEffect ("patrol", true);
		name = "Patrol";
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
		if( vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
		{
			currentWP++;
			if(currentWP >= waypoints.Length)
			{
				currentWP = 0;
			}
			completed = true;
		}
		agent.SetDestination( waypoints[currentWP].transform.position );
		return true;
	}
	
}
