using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : GAgent
{
    // Start is called before the first frame update
    new void Start()//add the "new" keyword for any class inheriting from GAgent.
    {
        //All of the main goals for the patient.
        base.Start();
        SubGoal s1 = new SubGoal("isWaiting", 1, true); //goal, priority, boolean. This will remove is from being a goal once its true
        goals.Add( s1, 3);//add s1 back to the list of goals with a priority of 3. 

        SubGoal s2 = new SubGoal("isTreated", 5, true);//highest priority.
        goals.Add( s2, 3); //the higher the number, the higher the action priority.

        SubGoal s3 = new SubGoal("atHome", 4, true);
        goals.Add( s3, 3);
    }

    
}
