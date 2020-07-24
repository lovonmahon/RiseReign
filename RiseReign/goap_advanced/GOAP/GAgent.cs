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
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
    public GInventory inventory = new GInventory();//all agent can access the global inventory
    public WorldStates beliefs = new WorldStates();//belief system for agents.

    GPlanner planner;
    Queue<GAction> actionQueue;
    public GAction currentAction;//what the agent is doing at a particular time
    SubGoal currentGoal;//What is the current goal of the agent?

    Vector3 destination = Vector3.zero;

    // Start is called before the first frame update
    public void Start()
    {
        GAction[] acts = this.GetComponents<GAction>();//get all the actions of type GAction.
        foreach(GAction a in acts)
            actions.Add(a);
    }

    bool invoked = false;
    void CompleteAction()
    {
        currentAction.running = false;//finished action, plan again.
        currentAction.PostPerform();
        invoked = false;
    }

    void LateUpdate()
    {
        if( currentAction != null && currentAction.running )
        {
            //manually calculating remaining distance. Navmesh not accurate.
            float distanceToTarget = Vector3.Distance(destination, this.transform.position);
            if( distanceToTarget < 2.0f)//( currentAction.agent.hasPath && currentAction.agent.remainingDistance < 2.0f)//navmesh code
            {
                if( !invoked)
                {
                    Invoke("CompleteAction", currentAction.duration);
                    invoked = true;
                }
            }
            return;
        }

        if( planner == null || actionQueue == null )//if agent has no plan to work on...
        {
            planner = new GPlanner();
            //sort through the goals using the LINQ namespace.
            var sortedGoals = from entry in goals orderby entry.Value descending select entry;

            //loop the goals

            foreach( KeyValuePair<SubGoal, int> sg in sortedGoals)
            {
                actionQueue = planner.plan(actions, sg.Key.sgoals, beliefs);//plans actions based on agent's beliefs.
                if(actionQueue != null)
                {
                    currentGoal = sg.Key;
                    break;
                }
            }
        }

        if( actionQueue != null && actionQueue.Count == 0 )
        {
            if( currentGoal.remove )
            {
                goals.Remove( currentGoal );
            }
            planner = null;
        }

        if( actionQueue != null && actionQueue.Count > 0 )
        {
            currentAction = actionQueue.Dequeue();
            if( currentAction.PrePerform())
            {
                if( currentAction.target == null && currentAction.targetTag != "")
                {
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag );
                }

                if( currentAction.target != null)
                {
                    currentAction.running = true;
                    destination = currentAction.target.transform.position;
                    //this will find the object named "Destination" for each resource.
                    Transform dest = currentAction.target.transform.Find("Destination");
                    if(dest != null)
                    {
                        destination = dest.position;
                    }
                    currentAction.agent.SetDestination( destination);
                }
            }
            else
            {
                actionQueue = null;//force the agent to go replan and not get stuck in the middle of a plan.
            }
        }
    }
}
