using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RiseReign;

public class CanSeeAction : GoapAction {

	//[SerializeField] float timeBetweenAttack = 1.0f;
	   
	bool m_sawPlayer = false;
    Animator anim;
    Sight sight;

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        sight = gameObject.GetComponent<Sight>();        
    }
    
    public CanSeeAction(){
		addPrecondition("canSeePlayer", false);
		addEffect ("canSeePlayer", true);
		//addEffect ("doJob", true);
    	name = "Can see the player";
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
		return false;
	}

	public override bool checkProceduralPrecondition(GameObject agent)
	{
		if( sight.m_canSeePlayer == true)
		{
			target = GameObject.FindWithTag("Player");
			if (target != null)
			{
				Debug.Log("I can see the player now");
				return true;
			}
		}	
		return false;
	}

	public override bool perform(GameObject agent)
	{
		m_sawPlayer = true;
	    return m_sawPlayer;
	    Debug.Log("Ah ketch eem!");	
        return true;
	}
}
