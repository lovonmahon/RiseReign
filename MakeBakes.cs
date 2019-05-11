using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBakes : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float workDuration = 2; // seconds
	public Inventory stockpile;
	Inventory inv;
	Animator anim;
	
	public MakeBakes () {
		addPrecondition ("hasBakingFlour", true); 
		addEffect ("hasBakes", true);
		name = "MakeBakes";
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
			anim.SetBool("cook", true);
			Debug.Log("Starting: " + name);
			startTime = Time.time;
			anim.SetTrigger("prepareMeal");
		}

		if (Time.time - startTime > workDuration) 
		{
			Debug.Log("Finished: " + name);
			stockpile.bakingFlour -= 1;
			inv.Bakes += 4;
			completed = true;
			anim.SetBool("cook", false);
		}
		return true;
	}
	
}
