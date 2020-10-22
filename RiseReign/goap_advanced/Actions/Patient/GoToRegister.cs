using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRegister : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        //the patient knows it is at the hospital.
        beliefs.ModifyState("atHospital", 0);
        return true;
    }
}
