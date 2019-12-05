using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wolf : Animals
{
	/**
	 * The Wolf's main goal is whatever Wolves do 
	 */
	public override HashSet<KeyValuePair<string,object>> CreateGoalState () {
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		
		goal.Add(new KeyValuePair<string, object>("patrol", true ));
		goal.Add(new KeyValuePair<string, object>("hunt", true ));
		goal.Add(new KeyValuePair<string, object>("rest", true ));
		goal.Add(new KeyValuePair<string, object>("fight", true ));
		goal.Add(new KeyValuePair<string, object>("flee", true ));
		return goal;
	}

}
