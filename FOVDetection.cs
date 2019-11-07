using System;
using UnityEngine;


namespace RiseReign
{



    public class FOVDetection : MonoBehaviour
    {
    	#region variables
    	pulic Transform player;
    	public float maxAngle;
    	public float maxRadius;
    
        public bool isInFOV = false;
    	
    	#endregion
    	
    	#region gizmos
    	private void OnDrawGizmos()
    	{
    		Gizmos.color = Color.yellow;
    		Gizmos.DrawWireSphere(transform.position, maxRadius);
    		
    		//Quaternion.AngleAxis (angle, axis to rotate on).
    		Vector3 fovLine1 = Quaternion.AngleAxis( maxAngle, transform.up) * transform.forward * maxRadius;//Rotating the forward.
    		Vector3 fovLine2 = Quaternion.AngleAxis( -maxAngle, transform.up) * transform.forward * maxRadius;
    		
    		Gizmo.color = Color.blue;
    		Gizmo.DrawRay(transform.position, fovLine1);
    		Gizmo.DrawRay(transform.position, fovLine2);
    		
    		//Line between AI and player.
    		if(!isInFOV)
            {
                Gizmo.color = Color.red;
            }
    		else
            {
                Gizmo.color = Color.green;
            }
            Gizmo.DrawRay(transform.position, (player.position-transform.position).normalized * maxRadius);
    		
    		
    		Gizmo.color = Color.black;
    		Gizmo.DrawRay(transform.position, transform.forward * maxRadius);
    	}	
    	#endregion
    	#region functions
    	public static bool inFOV( Transform checkingObject, Transform target, float maxAngle, float maxRadius)
	    {
		    Collider[] overlaps = new Collider[10];
		    int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps); //checkingObject is the AI, overlaps is the returned collider result that is checked.
		
            for (int i = 0; i < count + 1; i++)
            {
                    if(overlaps[i] !=null)
                    {
                           if(overlaps[i].transform == target)
                           {
                               Vector3 directionBetween = (target.position - checkingObject.position).norlamized;
                               directionBetween.y *= 0;//Prevent the height from being a factor in calculating the angle, for accuracy.

                               float angle = Vector3.Angle(checkngObject.forward, directionBetween);

                               if(angle <= maxAngle)
                               {
                                   Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                                   RaycastHit hit;
		    					   
		    					   if(Physics.Raycast(ray, out hit, maxRadius)
		    					   {
		    							if(hit.transform == target)
		    							{
		    								return true;
		    							}
		    					   }


                               }
                           }
                    }
            }
            
            return false;
        }
    	#endregion
    
        void Update()
        {
            isInFOV = inFOV( transform, player, maxAngle, maxRadius);
        }
    }
}
