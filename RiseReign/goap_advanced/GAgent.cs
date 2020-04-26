using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SubGoal
{
    public Dictionary<string, int> sgoals;
    public bool remove;

    public SubGoal( string s, int i, bool r)
    {
        sgoals = new Dictionary<string, int>();
        sgoals.Add( s, i);
        remove = r;
    }
}

public class GAgent : MonoBehaviour
{
    public List<GAction> actions = new List<GAction>();
    public Dictionary<SubGoal, int> goals = new Divtionary<SubGoal, int>();

    GPlanner planner;
    Queue<GAction> actionQueue;
    public GAction currentAction;//what the agent is doing at a particular time
    SubGoal currentGoal;//What is the current goal of the agent?

    // Start is called before the first frame update
    void Start()
    {
        GAction[] acts = this.GetComponents<GAction>();//get all the actions of type GAction.
        foreach(GAction a in acts)
            actions.Add(a);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
