using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
//To create different worker classes, rename this class to suit.

public class Worker : MonoBehaviour, IGoap
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
	[SerializeField] float speed = 1.0f;
	
	bool stopAtTarget = false;
	//String state = "WORK";

	void Start()
	{
		agent = this.GetComponent<NavMeshAgent>();
		anim = this.GetComponent<Animator>();
		inv = this.GetComponent<Inventory>();
		stockpile = this.GetComponent<Inventory>();
	}

	public HashSet<KeyValuePair<string,object>> GetWorldState () 
	{
		HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();
		worldData.Add(new KeyValuePair<string, object>("damagePlayer", false ));
		
		return worldData;
	}

	public HashSet<KeyValuePair<string,object>> CreateGoalState ()
	{
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		goal.Add(new KeyValuePair<string, object>("doJob", true ));
	

		return goal;
	}


	public virtual bool MoveAgent(GoapAction nextAction) {
		float theDistance = Vector3.Distance(transform.position, nextAction.transform.position);
		
		//if we don't need to move anywhere
		
		if(previousDestination == nextAction.target.transform.position)
		{
			nextAction.setInRange(true);
			return true;
		}
	/* if (agent.hasPath && agent.remainingDistance < 2) {
			nextAction.setInRange(true);
			previousDestination = nextAction.target.transform.position;
			return true;
		}*/
		if(theDistance < visDist)
		{
			agent.isStopped = false;
			agent.SetDestination(nextAction.transform.position);
		}
		
		if(theDistance <= meleeDist)
		{
			nextAction.setInRange(true);
			return true;
		}
		else
		{
			return false;
		}
		
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
			//this.transform.LookAt(target.position);//look at target
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
