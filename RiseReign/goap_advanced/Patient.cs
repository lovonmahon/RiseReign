using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : GAgent
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("isWaiting", 1, true); //goal, priority, boolean. This will remove is from being a goal once its true
        goals.Add( s1, 3);//add s1 back to the list of goals with a priority of 3. 
    }

    
}
