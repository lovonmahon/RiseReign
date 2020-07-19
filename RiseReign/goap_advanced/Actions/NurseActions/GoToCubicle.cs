using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCubicle : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");//call this function from the GInventory class.
        if(target == null)
        {
            return false;
        }
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        //Add a state to the world
        GWorld.Instance.GetWorld().ModifyState("TreatingPatient", 1);//Inject in the world state that a single patient is waiting.
        GWorld.Instance.AddCubicle(target);//Make th cubicle available again once it's use is completed.
        //Once the patient is treated, remove the cubicle form the patient's inventory
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", 1);//Change the state so other agents can know there's a free cubicle.
        //Make sure only one of the agents involved in the same scenario does this to avoid duplicate states etc.

        return true;
    }
}
