using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Farmer : MonoBehaviour, IGoap
{
	NavMeshAgent agent;
	Vector3 previousDestination;
	Inventory inv;
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
		inv = this.GetComponent<Inventory>();
	}

	public HashSet<KeyValuePair<string,object>> GetWorldState () 
	{
		HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();	
		return worldData;
	}


	public HashSet<KeyValuePair<string,object>> CreateGoalState ()
	{
		HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		goal.Add(new KeyValuePair<string, object>("doJob", true ));

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
