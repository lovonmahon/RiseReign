using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("clean", 1, false); //goal, priority, boolean. This will remove it from being a goal once its true. false keeps it repeating.
        goals.Add( s1, 1);//add s1 back to the list of goals with a priority of 3. 
    }
}

      
       

    
