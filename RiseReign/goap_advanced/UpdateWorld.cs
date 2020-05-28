using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    public Text states;
    
    // This is just to debug the world states during runtime. 
   
    void LateUpdate()
    {
        Dictionary<string, int> worldstates = GWorld.Instance.GetWorld().GetStates();
        states.text = "";
        foreach( KeyValuePair<string, int> s in worldstates)
        {
            states.text += s.Key + ", " + s.Value + "\n";
        }
    }
}
