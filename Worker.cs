using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
//To create different worker classes, rename this class to suit.

public abstract class Worker : MonoBehaviour, IGoap
{
	NavMeshAgent agent;
	Animator anim;
	Vector3 previousDestination;
	Inventory inv;
	public Inventory stockpile;
	[SerializeField] float rotationSpeed = 2.0f;
	[SerializeField] float visDist = 20.0f;
	[SerializeField] float visAngle = 30.0f;
	[SerializeField] float shootDist = 20.0f;
	[SerializeField] float throwDist = 10.0f;
	[SerializeField] float meleeDist = 1.0f;
	//String state = "WORK";

	void Start()
	{
		agent = this.GetComponent<NavMeshAgent>();
		anim = this.GetComponent<Animator>();
		inv = this.GetComponent<Inventory>();
		stockpile = GetComponent<Inventory>();
	}

	public HashSet<KeyValuePair<string,object>> GetWorldState () 
	{
		HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();
		worldData.Add(new KeyValuePair<string, object>("hasFishingRod", (inv.fishingRod > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasWheat", (inv.Wheat > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBakes", (inv.Bakes > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBakingFlour", (inv.Flour > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasRawFlour", (inv.RawFlour > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasMeat", (inv.Meat < 2) ));
		worldData.Add(new KeyValuePair<string, object>("hasFish", (inv.Fish > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasHerbs", (inv.Herbs > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBerries", (inv.Berries > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasManure", (inv.Manure > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasHammer", (inv.Hammer > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasPlanks", (inv.Planks > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasWeapon", (inv.Weapon > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasNails", (inv.Nails > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasCoins", (inv.Coins > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasTrap", (inv.Trap > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasAnimalCaught", (inv.CaughtAnimal > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasCocoaBallsocoaBalls", (inv.cocoaBalls > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasCocoaTea", (inv.CocoaTea > 1) ));
		
		
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


	public virtual bool MoveAgent(GoapAction nextAction) {
		
		//if we don't need to move anywhere
		if(previousDestination == nextAction.target.transform.position)
		{
			nextAction.setInRange(true);
			return true;
		}
		
		agent.SetDestination(nextAction.target.transform.position);
		
		if (agent.hasPath && agent.remainingDistance <= meleeDist) {
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
			UpdateAnimator();//to match animation to velocity.
			//code to rotate character to look at player taken from 'line of sight' in penny udemy.
			if(toTarget.magnitude < visDist && turnAngle < visAngle)
			{			
			toTarget.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
						  Quaternion.LookRotation(toTarget), 
						  Time.deltaTime * rotationSpeed);		

			}
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
	
	private void UpdateAnimator()//taken from Mover.cs script to match animation with velocity.
	{
		Vector3 velocity = GetComponent<NavMeshAgent>().velocity;//get velocity of navmeshagent
		Vector3 localVelocity = transform.InverseTransformDirection(velocity);//takes global and trafers to local velocity
		float speed = localVelocity.z;//for forward direction.
		GetComponent<Animator>().SetFloat("forwardSpeed", speed);//forward speed is the parameter on the blendtree for basic movement.  The speed variable is passed in to adjust speed from local velocity.
	}
}
