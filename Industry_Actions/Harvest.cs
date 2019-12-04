using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float workDuration = 10f; // seconds
	
	public Harvest () {
		addEffect ("hasWheat", true);
		name = "Harvest";
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
		//this.GetComponent<Farmer>().travelSpeed = 1.5f;
		return true;
	}
	
	public override bool perform (GameObject agent)
	{
		this.GetComponent<Animator>().SetFloat("forwardSpeed", 0);
		

		if (startTime == 0)
		{
			this.GetComponent<Animator>().SetBool("farm", true);
			//Debug.Log("Starting: " + name);
			startTime = Time.time;
		}

		if (Time.time - startTime > workDuration) 
		{
			//Debug.Log("Finished: " + name);
			completed = true;
			this.GetComponent<Animator>().SetBool("farm", false);
		}
		return true;
	}
	
}
