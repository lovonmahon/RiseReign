using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Alligator : Enemy {

	NavMeshAgent nav;
  Animator anim;
  
  // Use this for initialization
	void Start () {
		stamina = 100f;
		health = 50;
		speed = 20;
		strength = 10;
		regenRate = .5f;
		maxStamina = 100f;

		terminalSpeed = speed / 10;
		initialSpeed = (speed / 10) / 2;
		acceleration = (speed / 10) / 4;
   
		animator = gabeObject.GetComponent<Animator>();
		player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
		nav = gameObject.GetComponent<NavMeshAgent>();	
	}

	public override void passiveRegen(){
		stamina += regenRate;
	}

	public override HashSet<KeyValuePair<string, object>> createGoalState(){
		HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>> ();
		goal.Add (new KeyValuePair<string, object> ("damagePlayer", true));
		goal.Add (new KeyValuePair<string, object> ("stayAlive", true));
		goal.Add(new KeyValuePair<string, object>("hasMeat", true ));//go hunt an animal
		return goal;
	}
}
