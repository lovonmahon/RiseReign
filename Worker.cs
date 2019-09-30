using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public abstract class Worker : MonoBehaviour, IGoap
{
	NavMeshAgent agent;
	Vector3 previousDestination;
	Inventory inv;
	public Inventory windmill;
	
	//public Vector3 goalDestination;
	public bool _interrupt = false;

	void Start()
	{
		agent = this.GetComponent<NavMeshAgent>();
		inv = this.GetComponent<Inventory>();
	}

	public HashSet<KeyValuePair<string,object>> GetWorldState () 
	{
		HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();
		worldData.Add(new KeyValuePair<string, object>("hasStock", (windmill.flourLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasFlour", (inv.flourLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasDelivery", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("runAway", false ));
				
		return worldData;
	}


	public abstract HashSet<KeyValuePair<string,object>> CreateGoalState ();
	


	public bool MoveAgent(GoapAction nextAction) {
		
		//if we don't need to move anywhere
		if(previousDestination == nextAction.target.transform.position)
		{
			nextAction.setInRange(true);
			return true;
		}
		
		agent.SetDestination(nextAction.target.transform.position);
		/*if(!_interrupt)
		{
			//Abort the previous plan.
			PlanAborted (GoapAction aborter);
			//Pursue new course.
			agent.SetDestination( goalDestination );
		}*/	
		
		if (agent.hasPath && agent.remainingDistance < 2) {
			nextAction.setInRange(true);
			previousDestination = nextAction.target.transform.position;
			return true;
		} else
			return false;
	}

	void Update()
	{
		if(agent.hasPath)
		{
			Vector3 toTarget = agent.steeringTarget - this.transform.position;
         	float turnAngle = Vector3.Angle(this.transform.forward,toTarget);
         	agent.acceleration = turnAngle * agent.speed;
		}
	}

	public void PlanFailed (HashSet<KeyValuePair<string, object>> failedGoal)
	{

	}

	public void PlanFound (HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
	{

	}

	public void ActionsFinished ()
	{

	}

	public void PlanAborted (GoapAction aborter)
	{

	}
}
