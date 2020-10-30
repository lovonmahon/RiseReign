using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : GAgent
{
    int health = 100;


    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("Feed", 1, false); //goal, priority, boolean. False keeps it repeating, true removes the goal for good when completed.
        goals.Add( s1, 1);

        Invoke("Retreat", Random.Range(10.0f, 30.0f));
    }

    // Update is called once per frame
    void Retreat()
    {
        if(health < 30)
        {
            beliefs.ModifyState("weakened", 0);
        }
        
        //Invoke("GetTired", Random.Range(10.0f,20.0f));//Once the Start() invokes this, it will continue to invoke itself randmly forever.
        //Call the toilet relief method for the first time.
        //Invoke("NeedsRestroomBreak", Random.Range(5.0f,10.0f));//Invoke restroom break need.
    }
}
