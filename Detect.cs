using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : Monobehaviour
{

    public String tag; //tag we want to avoid.
    private bool avoid = false;
    
    [Header"Sensors"]
    
    public float sensorLength = 5f;
    public Vector3 frontSensorPosition = new Vector3( 0f, 0.2f, 0.5f );
    public float sideSensorPosition = 0.2f;
    public float frontSensorAngle = 80.0f;
    float avoidMultiplier = 0;
    avoiding = false;
    
    private void Sensors()
    {
    	Raycast hit;
    	Vector3 sensorStartPos = transform.position + frontSensorPosition;//origin
    		
    	//front sensor
    	if(Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
    	{
    		if (hit.collider.CompareTag(tag)
    		{
    			Debug.DrawLine(sensorStartPos, hit.point);
    			avoiding = true;
    		}
    		
    	}
    	
    	
    	//right sensor
    	if(Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
    	{
    		if (hit.collider.CompareTag(tag)
    		{
    			Debug.DrawLine(sensorStartPos, hit.point);
    			avoiding = true;
    		}
    	}
    	
    	
    	//left sensor
    	if(Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
    	{
    		if (hit.collider.CompareTag(tag)
    		{
    			Debug.DrawLine(sensorStartPos, hit.point);
    			avoiding = true;
    		}
    	}
    	
    	
    }
}	
