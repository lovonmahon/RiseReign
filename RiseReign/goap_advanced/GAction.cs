using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;//target
    public GameObject targetTag;//find ased on tag
    public float duration = 0;
    public WorldState[] preConditions;
    public worldState[] afterEffects;
    public NavMeshAgent agent;

    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;

    public WorldStates agentBeliefs;//agent's internal states, what they believe.

    public bool running = false;//is the state running?

    public GAction()
    {
        preconditions = new Dictionary<string, int>;
        effects = new Dictionary<string, int>;
    }

    public void Awake()
    {
        agent = this.ameObject.GetComponent<NavMeshAgent>();

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
            return true;
        }
    }

    public abstract bool PrePerform();//Can add custom code as extra checks
    public abstract bool PostPerform();//Can add custom code as extra checks
    
}
