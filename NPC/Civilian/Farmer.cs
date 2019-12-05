using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Farmer : Worker
{
	/**
	 * The Farmer's main goal is to farm but can engage in other 
	 * activities when needed.
	 */
	public override HashSet<KeyValuePair<string,object>> CreateGoalState () {
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		
		goal.Add(new KeyValuePair<string, object>("collectWater", true ));
		goal.Add(new KeyValuePair<string, object>("harvest", true ));
		goal.Add(new KeyValuePair<string, object>("plant", true ));
		goal.Add(new KeyValuePair<string, object>("husbandry", true ));
		goal.Add(new KeyValuePair<string, object>("processMeat", true ));
		goal.Add(new KeyValuePair<string, object>("rest", true ));
		goal.Add(new KeyValuePair<string, object>("fight", true ));
		goal.Add(new KeyValuePair<string, object>("flee", true ));
		return goal;
	}

}
