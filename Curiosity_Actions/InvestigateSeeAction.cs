using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RiseReign;

public class InvestigateSeeAction : GoapAction {

    Animator anim;
    AIMemory memory;
    Sight sight

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        memory = gameObject.GetComponent<AIMemory>();        
        sight = gameObject.GetComponent<Sight>(); 
    }
    
    public InvestigateSeeAction(){
		addPrecondition("shouldInvestigate", false);
		addEffect ("investigate", true);
		//addEffect ("doJob", true);
    	name = "Investigate the player's last known position";
	}

	void Update()
    {
        //
    }
    
    public override void reset() {
		target.transform.position = null;
	}

	public override bool isDone(){
		return m_investigate;
	}

	public override bool requiresInRange(){
		return true;
	}

	public override bool checkProceduralPrecondition(GameObject agent)
	{
		if( memory.alert == true)
		{
			target.transform.position = sight.m_playerLastKnownPosition;
			return true;
		}	
		return false;
	}

	public override bool perform(GameObject agent)
	{
		m_investigate = true;
	    return m_investigate;
        return true;
	}
