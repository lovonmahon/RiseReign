using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemovePatient();//removes the patient from the queue so he/she no longer can be considered waiting to be checked
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
