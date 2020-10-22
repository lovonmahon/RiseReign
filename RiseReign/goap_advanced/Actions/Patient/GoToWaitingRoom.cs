using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingRoom : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        //Inject in the world state that a single patient is waiting.
        GWorld.Instance.GetWorld().ModifyState("Waiting", 1);
        //This will actually add the patient to the queue for the nurse to treat.
        GWorld.Instance.GetQueue("patients").AddResource(this.gameObject);
        //The patient will inject this as a precondition before being treated.
        beliefs.ModifyState("atHospital", 1);
        return true;
    }
}
