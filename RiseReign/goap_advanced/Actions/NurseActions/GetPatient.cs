using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GAction
{
    GameObject resource;//Any game object to be used.

    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("patients").RemoveResource();//removes the patient from the queue so he/she no longer can be considered waiting to be checked
        if(target == null)
        {
            return false;
        }
        //Take a cubicle out of the waiting list queue to be used.
        resource = GWorld.Instance.GetQueue("cubicles").RemoveResource();
        //check to make the resource is not null.
        if( resource != null )
        {
            inventory.AddItem(resource);//use that cubicle
        }

        else
        {
            GWorld.Instance.GetQueue("patients").AddResource(target);//if the cubicle is not available, add the patient back to the waiting list until one becomes available.
            target = null;
            return false;
        }
        //If there is a cubicle and a patient available, lessen the count of available cubicles.
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", -1);

        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Waiting", -1);//lessen the count of waiting patients since one is getting treated.
        if(target)
        {
            target.GetComponent<GAgent>().inventory.AddItem(resource);//add the cubicle to the patient's inventory to be used
        }
        return true;
    }
}
