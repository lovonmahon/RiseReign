using UnityEngine;
using UnityEngine.AI;

//Moving agents on a navmesh
public class Mover : MonoBehaviour{
	[SerializeField] Transform target;
	void Update(){
		if(Inout.GetMouseButonDown(0)){
			MoveToCursor();
		}
	}
	
	private void MoveToCursor(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosiiton);//struct representing an infinite line at origin and going in some direction.
		RaycastHit hit; // struct to get information from the ray.
		bool hasHit = Physics.Raycast(ray, out hit);// the ray has to go out and hit something.
		if (hasHit)
		{
			GetComponent<NavMeshAgent>().destination = hit.point;//grab the navmesh component and set the destination to where the hit point was.
		}
	}
}
	
