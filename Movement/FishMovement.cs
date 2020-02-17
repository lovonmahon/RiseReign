using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//C# version to Creating a Survival Game in Unity: Part 9 - Basic Fishing & AI by SpeedTutor

public class FishMovement : MonoBehaviour
{
	Transform[] fishTarget;
	bool isSwimming = false;
	
	[SerializeField]
	float swimSpeed = 2.0f;

	Transform newTarget;//Destinations for fish to swim to.

	Animator fishAnim;
	void Start()
	{
		fishAnim = GetComponent<Animator>();
		fishAnim.SetBool("swim", true);
	}

	void Update()
	{
		if( isSwimming == false )
		{
			newTarget = fishTarget[Random.Range(0, fishTarget.length)];//Range starting from 0 to the max number in the array. get a random target.
			isSwimming = true;
		}

		transform.position = Vector3.MoveTowards( transform.position, newTarget.position, swimSpeed * Time.deltaTime );
		transform.LookAt( newTarget );

		if( transform.position == newTarget.position )
		{
			isMoving = false;
		}
	}
}
