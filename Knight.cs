using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Knight : Worker {

	GameObject player;
	void Start () {		
	

		player.FindWithTag("Player").GetComponent<ThirdPersonCharacter>();
	}

	
	public override HashSet<KeyValuePair<string, object>> createGoalState(){
		HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>> ();
		goal.Add (new KeyValuePair<string, object> ("damagePlayer", true));
		goal.Add (new KeyValuePair<string, object> ("stayAlive", true));
		return goal;
	}

	
}
