using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestroomBreak : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        //Remove an office from the queue to be used
        target = GWorld.Instance.GetQueue("restrooms").RemoveResource();
        if(target == null)//if there are no restrooms available, return false
        {
            return false;
        }
        //If there is an office in the queue for use, add it to the agent's inventory.
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeRestRoom", -1);//lessen the available amount of rest rooms since it is being used.
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        //add the restroom back to the available for use queue
        GWorld.Instance.GetQueue("restrooms").AddResource(target);
        //remove the restroom from the agent directory  No longer needed
        inventory.RemoveItem(target);
        //Update the available office to 1.
        GWorld.Instance.GetWorld().ModifyState("FreeRestRoom", 1);
        //The agent has used the toilet and the need it reset.
        beliefs.RemoveState("toiletbreak");
        return true;
    }
}
