using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Raider : Military
{
	/**
	 * The Raider's main goal is ruthless stealing of goods but can engage in other 
	 * activities when needed.
	 */
	public override HashSet<KeyValuePair<string,object>> CreateGoalState () {
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		
		goal.Add(new KeyValuePair<string, object>("steal", true ));
		goal.Add(new KeyValuePair<string, object>("investigate", true ));
		goal.Add(new KeyValuePair<string, object>("escort", true ));
		goal.Add(new KeyValuePair<string, object>("rest", true ));
		goal.Add(new KeyValuePair<string, object>("fight", true ));
		goal.Add(new KeyValuePair<string, object>("flee", true ));
		goal.Add(new KeyValuePair<string, object>("embark", true ));//use for boats/ships
		goal.Add(new KeyValuePair<string, object>("disembark", true ));//use for boats/ships
		return goal;
	}

}
