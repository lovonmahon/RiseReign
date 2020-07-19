using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatPatient : GAction
{
    GameObject resource;//Any game object to be used.
    //target = GWorld.Instance.RemovePatient();
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");//Go to the cubicle to treat the waiting patient.
        if(target == null)
        {
            return false;
        }
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", 1);//after patient in finished treated, the cubicle must become available again.
        //GWorld.Instance.GetWorld().ModifyState("FreeCubicle", 1);
        /*if(target)
        {
            target.GetComponent<GAgent>().inventory.AddItem(resource);//add the cubicle to the patient's inventory to be used
        }*/
        return true;
    }
}
