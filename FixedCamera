using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//simple fixed camera

public class FixedCamera : MonoBehaviour{

	[SerializeField] Transform target;
	
	void LateUpdate()//Late update allows all physics to calculate in an earlier frame then the camera frame is updated.  This allows for smooth display
	{
		transform.position = target.position;
	}
}
	
