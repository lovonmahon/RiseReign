using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        beliefs.RemoveState("atHospital");//Agent knows it's no longer at hospital; any hospital related actions will not be possible.
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        Destroy(this.gameObject, 1.0f);//Destroys the GO once it finished it's task...unless they need to remain in the world. Delay 1 second for any processing that needs to finish.
        //For performance optimization, create a pool of patien prefab to re-use.
        return true;
    }
}
