using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GAction
{
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        return true;
    }

    // Update is called once per frame
    public override bool PostPerform()
    {
        Destroy(this.gameObject);//Destroys the GO once it finished it's task...unless they need to remain in the world.
        //For performance optimization, create a pool of patien prefab to re-use.
        return true;
    }
}
