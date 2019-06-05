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
	public GameObject healingSpots[];//array of places to hide/heal.
	int currentHealingSpot = 0;
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
		currentHealingSpot = FindClosestSpot();
    }
    
    public EvadeAction(){
        addPrecondition("runAway", false);
		addEffect ("hasHealth", (health.currentHealth < 30));
		//cost = 1.0f;
        name = "EvadeAction";
	}

	void Update()
    {
        	float distance = Vector3.Distance(this.transform.position, target.transform.position);//calculate distance from transform to target.
		if(target != null && distance < threatDistance )
		{
			//transform.LootAt(target);//always look at the target
			if(avoid)
			{
				Vector3 targetCheck = transform.position - target.position;//second check distance to the target
				Vector3 goToPosition = transform.position + targetCheck;//Calculate flee distance to move away from target threat.
				agent.SetDestination(goToPosition);//Run!
			}
			
			if(injured)
			{
				Vector3 safeDist = healingSpots[currentHealingSpot].transform.position - transform.position;
				if(safeDist < arrivalAccuracy)
				{
					currentHealingSpot = FindClosestSpot();
				}
			}
    
		}
    }
	
    void FindCLosestSpot() //Based on Holistic3D tutorial 'AI: Finding the Closest Waypoint in Unity 5'
    {
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
    
    public override void reset() {
		avoid = false;
		target = null;
	}

	public override bool isDone(){
		return avoid;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent){
		target = GameObject.FindWithTag("Player");
		return target != null;
		if(health.currentHealth < 30)
		{
			agent.SetDestination(healingSpot.transform.position);
		}
        return true;
	}

	public override bool perform(GameObject agent)	        
        {
            isHiding = true;
	    avoid = true;
	    return true;
	}        
	
}
