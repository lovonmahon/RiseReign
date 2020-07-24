using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        //Remove an office from the queue to be used
        target = GWorld.Instance.RemoveOffice();
        if(target == null)//if there ar eno offices available, return false
        {
            return false;
        }
        //If there is an office in the queue for use, add it to the agent's inventory.
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeOffice", -1);//lessen the available amount of offices since it is being used.
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        GWorld.Instance.AddOffice(target);//add the office back to the available for use queue
        inventory.RemoveItem(target);//remove the office from the agne't directory  No longer needed
        GWorld.Instance.GetWorld().ModifyState("FreeOffice", 1);//Update the available office to 1.
        return true;
    }
}
