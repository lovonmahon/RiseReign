
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour {
//attach the safeHaven component to any hiding spot(currently only 1 supported)
    
    bool canSee = false;
	public GameObject[] healingSpots;//array of places to hide/heal.
	int currentHealingSpot = 0;
    [SerializeField] int los = 20; //Line of Sight.
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponentInChildren<Animator>();
		health = this.GetComponent<EnemyHealth>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
		health = this.GetComponent<EnemyHealth>();
		healingSpots = gameObject.GetComponent<safeHavenComponent>();
		currentHealingSpot = 0;
    }

    void Update(){
        FindHidingSpots();
        SpotTarget();
    }
    
    
    //Based on Holistic3D tutorial 'AI: Finding the Closest Waypoint in Unity 5'
    //The AI doesn't require sight for this, they will already know all of the spots but go to closest.
	void FindHidingSpots(){
        //Find the closest place to hide and heal.
        if(healingSpots.Length == 0) return -1;//if no spots are found return nothing.
	    int closest = 0;//Otherwise set the closest spot to the first location in the array.
	    float lastSpot = Vector3.Distance(this.transform.position, healingSpots[0].transform.position);//returns the distance between transform and last waypoint.
	    for(int i = 1; i < healingSpots.Length; i++)//Iterate over the remaining waypoints in the list to check which is closest to transform.
	    {
		    float newSpot = Vector3.Distance(this.transform.position, healingSpots[i].transform.position);
		    if(lastSpot > newSpot && i != currentHealingSpot)
		    {
		      closest = i;
		    }
            return closest;   
		}
    }

    void SpotTarget(){
        RaycastHit hit;//stores what was hit 
        float theDistance;//stores the distance of what was hit
        Vector3 forward = transform.TransformDirection(Vector3.forward)* los;
        if(Physics.Raycast(transform.position, (forward), out hit, layerMask))
        {
            //store the location in theDistance 
	        theDistance = hit.distance;
            Debug.DrawRay(transform.position, (forward), Color red);
        }

       

	
}
