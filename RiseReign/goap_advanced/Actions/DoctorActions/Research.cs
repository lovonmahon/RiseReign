using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        //Remove an office from the queue to be used
        target = GWorld.Instance.GetQueue("offices").RemoveResource();
        //if there ar eno offices available, return false
        if(target == null)
        {
            //No office available so return false
            return false;
        }
        //If there is an office in the queue for use, add it to the agent's inventory.
        inventory.AddItem(target);
        //lessen the available amount of offices since it is being used.
        GWorld.Instance.GetWorld().ModifyState("FreeOffice", -1);
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        //Add the office back to the available pool
        GWorld.Instance.GetQueue("offices").AddResource(target);
        //Remove the office from the agent's inventosy since it's no longer needed
        inventory.RemoveItem(target);
        //Give the office back to the world.
        GWorld.Instance.GetWorld().ModifyState("FreeOffice", 1);
        return true;
    }
}
