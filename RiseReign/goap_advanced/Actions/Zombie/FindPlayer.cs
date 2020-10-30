using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPlayer : GAction
{

    public override bool PrePerform()
    {
        target = GameObject.Find("Player");
        if(target == null)
        {
            return false;
        }
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        return true;
    }
}
