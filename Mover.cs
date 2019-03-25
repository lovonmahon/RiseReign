using UnityEngine;
using UnityEngine.AI;

//Moving agents on a navmesh
public class Mover : MonoBehaviour{
	[SerializeField] Transform target;
	void Update(){
		/*if(Inout.GetMouseButon(0)){
			MoveToCursor();
		}*/
		UpdateAnimator();//TO match animation to velocity of the agent.
	}
	
	private void MoveToCursor(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosiiton);//struct representing an infinite line at origin and going in some direction.
		RaycastHit hit; // struct to get information from the ray.
		bool hasHit = Physics.Raycast(ray, out hit);// the ray has to go out and hit something.
		if (hasHit)
		{
			MoveTo(hit.point);//Move to the destination point.
		}
	}
	
	public void MoveTo(Vector3 destination)
	{
		GetComponent<NavMeshAgent>().destination = destination;
	}
	private void UpdateAnimator()
	{
		Vector3 velocity = GetCOmponent<NavMeshAgent>().velocity;//get velocity of navmeshagent
		Vector3 localVelocity = transform.InverseTransformDirection(velocity);//takes global and trafers to local velocity
		float speed = localVelocity.z;//for forward direction.
		GetComponent<Animator>().SetFloat("forwardSpeed", speed);//forward speed is the parameter on the blendtree for basic movement.  The speed variable is passed in to adjust speed from local velocity.
	}
}
	
	
