using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;//target
    public string targetTag;//find based on tag name
    public float duration = 0;
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent agent;
    public GInventory inventory;

    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;

    public WorldStates beliefs;//agent's internal states, what they believe.

    public bool running = false;//is the state running?

    public GAction()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    public void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();

        if(preconditions != null)
        {
            foreach( WorldState w in preConditions)
            {
                preconditions.Add( w.key, w.value);
            }
        }

        if(effects != null)
        {
            foreach( WorldState w in afterEffects)
            {
                effects.Add( w.key, w.value);
            }
        }
        inventory = this.GetComponent<GAgent>().inventory;
        //Needs to access the beliefs in order to confirm if an action can be run.
        beliefs = this.GetComponent<GAgent>().beliefs;
    }

    public bool IsAchievable()//does not require preconditions
    {
        return true;
    }

    public bool IsAchievableGiven( Dictionary<string, int> conditions)//are the required preconditions provided?
    {
        foreach( KeyValuePair<string,int> p in preconditions)
        {
            if( !conditions.ContainsKey( p.Key))
            {
                return false;
            }
        }
        return true;
    }

    public abstract bool PrePerform();//Can add custom code as extra checks
    public abstract bool PostPerform();//Can add custom code as extra checks
    
}
