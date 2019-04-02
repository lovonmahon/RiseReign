using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Raider : Enemy {

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

		animator = GetComponent<Animator> ();
		player = GameObject.Find ("Player").GetComponent<PlayerMovement>();

	}

	public override void passiveRegen(){
		stamina += regenRate;
	}

	public override HashSet<KeyValuePair<string, object>> createGoalState(){
		HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>> ();
		goal.Add (new KeyValuePair<string, object> ("damagePlayer", true));
		goal.Add (new KeyValuePair<string, object> ("stayAlive", true));
		goal.Add(new KeyValuePair<string, object>("hasFishingRod", true ));
		goal.Add(new KeyValuePair<string, object>("hasWheat", true ));
		goal.Add(new KeyValuePair<string, object>("hasBakes", true ));
		goal.Add(new KeyValuePair<string, object>("hasBakingFlour", true ));
		goal.Add(new KeyValuePair<string, object>("hasRawFlour", true ));
		goal.Add(new KeyValuePair<string, object>("hasMeat", true ));
		goal.Add(new KeyValuePair<string, object>("hasFish", true ));
		goal.Add(new KeyValuePair<string, object>("hasHerbs", true ));
		goal.Add(new KeyValuePair<string, object>("hasBerries", true ));
		goal.Add(new KeyValuePair<string, object>("hasManure", true ));
		goal.Add(new KeyValuePair<string, object>("hasHammer", true ));
		goal.Add(new KeyValuePair<string, object>("hasPlanks", true ));
		goal.Add(new KeyValuePair<string, object>("hasWeapon", true ));
		goal.Add(new KeyValuePair<string, object>("hasNails", true ));
		goal.Add(new KeyValuePair<string, object>("hasCoins", true ));
		goal.Add(new KeyValuePair<string, object>("hasTrap", true ));
		goal.Add(new KeyValuePair<string, object>("hasAnimalCaught", true ));
		goal.Add(new KeyValuePair<string, object>("hasCocoaBalls", true ));
		goal.Add(new KeyValuePair<string, object>("hasCocoaTea", true ));
		return goal;
	}
}
