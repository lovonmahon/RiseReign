using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlour : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float workDuration = 2; // seconds
	public Inventory stockpile;
	Inventory inv;
	Animator anim;
	
	public PickupFlour () {
		addPrecondition ("hasRawFlour", true); 
		addEffect ("hasBakingFlour", true);
		name = "PickupFlour";
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
			anim.SetBool("pickup", true);
			Debug.Log("Starting: " + name);
			startTime = Time.time;
		}

		if (Time.time - startTime > workDuration) 
		{
			Debug.Log("Finished: " + name);
			stockpile.bakingFlour -= 1;
			inv.bakingFlour += 1;
			completed = true;
			anim.SetBool("pickup", false);
		}
		return true;
	}
	
}
