using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWallAction : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float buildWallDuration = 30; // seconds
	public List<GameObject> walls = new List<GameObject>();//a list of all wall game objects
	//Health health;

	//The AI should go to which ever wall is damaged to repair it.
	
	void Start()
	{
		//health = gameObject.FindWithTag("Wall").GetComponent<Health>();

		foreach( GameObject wall in walls )
		{
			wall.GetComponent<BuildingHealth>();
		}
	}

	public BuildWallAction () {
		addPrecondition ("buildWall", false); 
		addEffect ("buildWall", true);
		name = "Build wall";
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
		foreach( GameObject wall in walls )
		{
			
			if( wall.GetComponent<BuildingHealth>.damage > 50 )
			{
				target = wall;
				return true;
			}
		}

		return false;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
		{
			Debug.Log("Starting: " + name);
			startTime = Time.time;
			//Play building animation
		}

		if (Time.time - startTime > buildWallDuration) 
		{
			Debug.Log("Finished: " + name);
			this.GetComponent<Inventory>().toolbox -= 1;
			completed = true;
			//Stop building animation.
		}
		return true;
	}
	
}
