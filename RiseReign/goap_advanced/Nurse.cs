using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : GAgent
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, true); //goal, priority, boolean. This will remove is from being a goal once its true
        goals.Add( s1, 1);//add s1 back to the list of goals with a priority of 3. 
    }

    
}