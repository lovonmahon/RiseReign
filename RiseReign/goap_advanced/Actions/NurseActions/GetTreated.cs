using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreated : GAction
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
        GWorld.Instance.GetWorld().ModifyState("Treated", 1);//Inject in the world state that a single patient is waiting.
        //Once the patient is treated, remove the cubicle form the patient's inventory
        inventory.RemoveItem(target);
        return true;
    }
}
