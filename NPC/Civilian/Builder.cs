using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Builder : Worker
{
	/**
	 * The Builders's main goal is construction but can engage in other 
	 * activities when needed.
	 */
	public override HashSet<KeyValuePair<string,object>> CreateGoalState () {
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		
		goal.Add(new KeyValuePair<string, object>("buildFence", true ));
		goal.Add(new KeyValuePair<string, object>("buildBoat", true ));
		goal.Add(new KeyValuePair<string, object>("buildSmallHouse", true ));
		goal.Add(new KeyValuePair<string, object>("buildBigHouse", true ));
		goal.Add(new KeyValuePair<string, object>("buildWall", true ));
		goal.Add(new KeyValuePair<string, object>("rest", true ));
		goal.Add(new KeyValuePair<string, object>("fight", true ));
		goal.Add(new KeyValuePair<string, object>("flee", true ));
		return goal;
	}

}
