using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Knight : Military
{
	/**
	 * The Knight's main goal is civil order and leadership but can engage in other 
	 * activities when needed.
	 */
	public override HashSet<KeyValuePair<string,object>> CreateGoalState () {
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		
		goal.Add(new KeyValuePair<string, object>("patrol", true ));
		goal.Add(new KeyValuePair<string, object>("investigate", true ));
		goal.Add(new KeyValuePair<string, object>("escort", true ));
		goal.Add(new KeyValuePair<string, object>("rest", true ));
		goal.Add(new KeyValuePair<string, object>("fight", true ));
		goal.Add(new KeyValuePair<string, object>("flee", true ));
		return goal;
	}

}
