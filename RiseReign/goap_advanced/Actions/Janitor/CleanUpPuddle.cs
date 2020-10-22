using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpPuddle : GAction
{
    // Start is called before the first frame update
   public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("puddles").RemoveResource();
        if(target == null)
            return false;
            inventory.AddItem(target);
            GWorld.Instance.GetWorld().ModifyState("FreePuddle", -1);//Remove 1 puddle in queue waiting to be cleaned

        return true;
    }
   
   public override bool PostPerform()
    {
        inventory.RemoveItem(target);//puddle is cleaned, 
        Destroy(target);
        return true;
    }
}
