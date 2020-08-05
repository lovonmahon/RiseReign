using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : GAgent
{
    // The bigger number takes priority for goals.
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("Research", 2, false); //goal, priority, boolean. This will remove it from being a goal once its true. false keeps it repeating.
        goals.Add( s1, 2);//add s1 back to the list of goals with a priority of 3. 

        SubGoal s2 = new SubGoal("rested", 1, false); //goal is to rest, and do not remove it as a goal, let it repeat.
        goals.Add(s2, 1);//priority here

        SubGoal s3 = new SubGoal("TakeRestroomBreak", 3, false); //goal is to use restroom, priority of 1 and do not remove it as a goal, let it repeat.
        goals.Add(s3, 3);

        Invoke("GetTired", Random.Range(10,20));//Invoke the GetTired() from the start.
        Invoke("NeedsRestroomBreak", Random.Range(5,10));//Invoke restroom break need.
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10,20));//Once the Start() invokes this, it will continue to invoke itself randmly forever.
    }

    void NeedsRestroomBreak()
    {
        beliefs.ModifyState("toiletbreak", 0);
        Invoke("NeedsRestroomBreak", Random.Range(5,10));//Once the Start() invokes this, it will continue to invoke itself randmly forever.
    }      

    //These base goals should not be injected into the world states or the agent's beliefs.
    //They are strictly
}