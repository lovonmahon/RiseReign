using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeAction : GoapAction {
//attach the safeHaven component to any hiding spot(currently only 1 supported)
	[SerializeField] float timeBetweenAttack = 1.0f;
    	EnemyHealth health;
    	Animator anim;
    	bool isHiding = false;
	bool avoid = false;
	bool injured = false;
	float threatDistance = 20.0f;
	public GameObject[] healingSpots;//array of places to hide/heal.
	int currentHealingSpot = 0;
	
	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
	health = this.GetComponent<EnemyHealth>();
	healingSpots = gameObject.GetComponent<safeHavenComponent>();	
    }
    
    public EvadeAction(){
        addPrecondition("runAway", false);
	addEffect ("hasHealth", (health.currentHealth < 30));
	//cost = 1.0f;
        name = "EvadeAction";
	}
      
    public override void reset() {
		avoid = false;
		target = null;
	    	isHiding = false;
	}

	public override bool isDone(){
		return avoid;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent){
	    if(healingSpots.Length == 0) return -1//if no spots are found return nothing.
	    int closest = 0;//Otherwise set the closest spot to the first location in the array.
	    float lastDist = Vector3.Distance(this.transform.position, healingSpots[0].transform.position);//returns the distance between transform and last waypoint.
	    for(int i = 1, i < healingSpots.Length, i++)//Iterate over the remaining waypoints in the list to check which is closest to transform.
	    {
		  float thisDist = Vector3.Distance(this.transform.position, healingSpots[i].transform.position);
		  if(lastDist > thisDist && i != currentHealingSpot)
		  {
			  closest = i;
		  }		   
	    }
	    return closest; 
    }

	public override bool perform(GameObject agent)	        
        {
            anim.SetTrigger("hidingAnimation");
	    isHiding = true;
	    avoid = true;
	    return true;
	}        
	
}
