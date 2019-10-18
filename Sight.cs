using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign
{    
    public class Sight : MonoBehaviour
    {
    
        //Try caching the animator if performance suffers from initializing it in the perform().
        /*void Awake(){
            anim = GameObject.GetComponent<Animator>();
        }*/
    
    
    
        public float goatDestination;
        public bool detected = false;
    
        void Start()
        {
    
        }
    
        void Update()
        {
             RaycastHit hit;
    
             float theDist;
             Vector3 forwardDist = transform.TransformDirection(Vector3.forward) * 20;
             Vector3 leftDist = transform.TransformDirection(Vector3.left) * 20;
             Vector3 rightdDist = transform.TransformDirection(Vector3.right) * 20;
    
             if(Physics.Raycast(transform.position, (forwardDist), out hit))
    	     {
    	        if(hit.collider.tag == "player" && health > 30)
    	        {
    		        theDist = hit.distance;
                    detected = true;
    	        }
             }	
    
            if(Physics.Raycast(transform.position, (leftDist), out hit))
            {
            	if(hit.collider.tag == "player" && health > 30)
            	{
            		theDist = hit.distance;
                    detected = true;
            	}
            }
    
            if(Physics.Raycast(transform.position, (rightdDist), out hit))
            {
            	if(hit.collider.tag == "player" && health > 30)
            	{
            		theDist = hit.distance;
                    detected = true;
            	}
            }
    
            else
            {
                detected = false;
            }
        }
    }
}


