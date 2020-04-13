using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Waypoint idea borrowed from Holistic3d 'Simple waypoint  pathfinding with the Line of Sight AI' and Daniel McCluskey Spy vs Guard AI.

public class  WP1Action : GoapAction {

	//public GameObject waypoint1;
	int currentWP= 0;
	float accuracyWP = 5.0f;
	bool completed = false;
	//float startTime = 0;
	//public float workDuration = 2; // seconds
	
	public PatrolAction () {
		//addPrecondition ("atWP1", false); 
		addEffect ("needsToHide", true);
		name = "WP1Action";
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
		Sight m_sight = this.GetComponent<Sight>();
		GameObject player = m_sight.GetVisibleTargets();

		if( player == null)
		{
			return true;
		}
		return false;
	}
	
	public override bool perform (GameObject agent)
	{
		completed = true
		return completed;
	}
	
}
