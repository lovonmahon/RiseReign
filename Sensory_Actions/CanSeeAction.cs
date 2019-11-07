using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeeAction : GoapAction {

	//[SerializeField] float timeBetweenAttack = 1.0f;
	FOVDetection fov;    
	bool m_sawPlayer = false;

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        fov = this.GetComponent<FOVDetection>();
    }
    
    public CanSeeAction(){
        addPrecondition("canSeePlayer", false);
	addEffect ("doJob", true);
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
		return m_sawPlayer;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent)
	{
		target = GameObject.FindWithTag("Player");
		if ( fov.isInFOV )
		{	
        	    return true;
		}
		return false;
	}

	public override bool perform(GameObject agent)
	{
	    m_sawPlayer = true;
	    //return m_sawPlayer;
            return true;
	}
}
