using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
//To create different worker classes, rename this class to suit.

public class Worker : MonoBehaviour, IGoap
{
	NavMeshAgent agent;
	Vector3 previousDestination;
	Inventory inv;
	public Inventory stockpile;

	void Start()
	{
		agent = this.GetComponent<NavMeshAgent>();
		inv = this.GetComponent<Inventory>();
		stockpile = GetComponent<Inventory>();
	}

	public HashSet<KeyValuePair<string,object>> GetWorldState () 
	{
		HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();
		worldData.Add(new KeyValuePair<string, object>("hasFishingRod", (inv.fishingRod > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasWheat", (inv.Wheat > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBakes", (inv.Bakes > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBakingFlour", (inv.wheatLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasRawFlour", (inv.breadLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasMeat", (inv.breadLevel < 2) ));
		worldData.Add(new KeyValuePair<string, object>("hasFish", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasHerbs", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBerries", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasManure", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasHammer", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasPlanks", (inv.breadLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasWeapon", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasNails", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasCoins", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasTrap", (inv.breadLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasAnimalCaught", (inv.breadLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasCocoaBallsocoaBalls", (inv.cocoaBalls > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasCocoaTea", (inv.cocoaBalls > 1) ));
		
		
		return worldData;
	}


	public HashSet<KeyValuePair<string,object>> CreateGoalState ()
	{
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		goal.Add(new KeyValuePair<string, object>("hasFishingRod", true ));
		goal.Add(new KeyValuePair<string, object>("hasWheat", true ));
		goal.Add(new KeyValuePair<string, object>("hasBakes", true ));
		goal.Add(new KeyValuePair<string, object>("hasBakingFlour", true ));
		goal.Add(new KeyValuePair<string, object>("hasRawFlour", true ));
		goal.Add(new KeyValuePair<string, object>("hasMeat", true ));
		goal.Add(new KeyValuePair<string, object>("hasFish", true ));
		goal.Add(new KeyValuePair<string, object>("hasHerbs", true ));
		goal.Add(new KeyValuePair<string, object>("hasBerries", true ));
		goal.Add(new KeyValuePair<string, object>("hasManure", true ));
		goal.Add(new KeyValuePair<string, object>("hasHammer", true ));
		goal.Add(new KeyValuePair<string, object>("hasPlanks", true ));
		goal.Add(new KeyValuePair<string, object>("hasWeapon", true ));
		goal.Add(new KeyValuePair<string, object>("hasNails", true ));
		goal.Add(new KeyValuePair<string, object>("hasCoins", true ));
		goal.Add(new KeyValuePair<string, object>("hasTrap", true ));
		goal.Add(new KeyValuePair<string, object>("hasAnimalCaught", true ));
		goal.Add(new KeyValuePair<string, object>("hasCocoaBalls", true ));
		goal.Add(new KeyValuePair<string, object>("hasCocoaTea", true ));

		return goal;
	}


	public bool MoveAgent(GoapAction nextAction) {
		
		//if we don't need to move anywhere
		if(previousDestination == nextAction.target.transform.position)
		{
			nextAction.setInRange(true);
			return true;
		}
		
		agent.SetDestination(nextAction.target.transform.position);
		
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
