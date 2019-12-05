using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shark : Animals
{
	/**
	 * The Shark's main goal is whatever Alligators do 
	 */
	public override HashSet<KeyValuePair<string,object>> CreateGoalState () {
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		
		goal.Add(new KeyValuePair<string, object>("investigate", true ));
		goal.Add(new KeyValuePair<string, object>("rest", true ));
		goal.Add(new KeyValuePair<string, object>("fight", true ));
		goal.Add(new KeyValuePair<string, object>("flee", true ));
		return goal;
	}

}
