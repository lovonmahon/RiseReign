using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeeAction : GoapAction {

	//[SerializeField] float timeBetweenAttack = 1.0f;
	FOVDetection fov;    
	//Try caching the animator if performance suffers from initializing it in the perform().
	/*void Awake(){
		anim = GameObject.GetComponent<Animator>();
	}*/

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        fov = this.GetComponent<FOVDetection>();
    }
    
    public CanSeeAction(){
        addPrecondition("canSeePlayer", true);
		addEffect ("doJob", true);
		//cost = 1.0f;
        name = "CanSeeAction";
	}

	void Update()
    {
        //
    }
    
    public override void reset() {
		target = null;
	}

	public override bool isDone(){
		return sawPlayer;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent){
		target = GameObject.FindWithTag("Player");
		fov.isInFOV = true;
        return true;
	}

	public override bool perform(GameObject agent){
		sawPlayer = true;
		return sawPlayer;
        return true;
	}
}
