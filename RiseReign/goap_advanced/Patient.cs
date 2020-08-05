using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : GAgent
{
    // The bigger number takes priority for goals.
    new void Start()//add the "new" keyword for any class inheriting from GAgent.
    {
        //All of the main goals for the patient.
        base.Start();
        SubGoal s1 = new SubGoal("isWaiting", 1, true); //goal, priority, boolean. This will remove is from being a goal once its true
        goals.Add( s1, 2);//add s1 back to the list of goals with a priority of 3. 

        SubGoal s2 = new SubGoal("isTreated", 1, true);//highest priority.
        goals.Add( s2, 3); //the higher the number, the higher the action priority.

        SubGoal s3 = new SubGoal("atHome", 1, true);
        goals.Add( s3, 1);

        SubGoal s4 = new SubGoal("TakeRestroomBreak", 1, false); //goal is to use restroom, priority of 1 and do not remove it as a goal, let it repeat.
        goals.Add(s4, 4);

        Invoke("NeedsRestroomBreak", Random.Range(5,10));//Invoke restroom break need.
    }

    void NeedsRestroomBreak()
    {
        beliefs.ModifyState("toiletbreak", 0);
        Invoke("NeedsRestroomBreak", Random.Range(5,10));//Once the Start() invokes this, it will continue to invoke itself randmly forever.
    }      

    //These base goals should not be injected into the world states or the agent's beliefs.
    //They are strictly

    
}
