using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAction : GoapAction {

	bool completed = false;
	float startTime = 0;
	public float hideDuration = 30; // seconds
	Animator anim;
	//LookAt lookTarget;
	GameObject player;
	
	void Start()
	{
		anim = this.GetComponent<Animator>();
		//lookTarget = this.GetComponent<LookAt>();
		player = gameObject.FindWithTag("Player");
	}

	public HideAction () {
		addPrecondition ("needsToHide", true);
		addEffect ("doJob", true);
		name = "Enter hiding area!";
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
		return false; //Should already be in a hiding area.
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{	
		//lookTarget.target = player.transform;
		float distFromPlayer = Vector3.Distance( player.transform.position, transform.position );//Check to see if distance from player >=20 meters.
		
		if( distFromPlayer > 20.0f )//If far enough away from player, crouch or whatever.
		return true;
	}
	
	public override bool perform (GameObject agent)
	{
		
		if (startTime == 0)
		{
			anim.SetBool( "hiding", true );
			//Debug.Log("Starting: " + name);
			startTime = Time.time;
		}

		if (Time.time - startTime > hideDuration) 
		{
			Debug.Log("Finished: " + name);
			//stock = gameObject.FindWithTag("stockpile").GetComponent<Stockpile>().fish += 1;
			completed = true;
			anim.SetBool( "hiding", false );
		}
		return true;
	}
	
}
