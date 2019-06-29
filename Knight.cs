using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Knight : Worker {

	GameObject player;
	
    void Start ()
    {
		//player = gameObject.FindWithTag("Player").GetComponent<ThirdPersonCharacter>();
	}

	public override HashSet<KeyValuePair<string, object>> CreateGoalState(){
		HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>> ();
		goal.Add (new KeyValuePair<string, object> ("damagePlayer", true));
		goal.Add (new KeyValuePair<string, object> ("stayAlive", true));
        goal.Add (new KeyValuePair<string, object> ("runAway", true));
		return goal;
	}

	
}
