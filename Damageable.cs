using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inspired by https://www.youtube.com/watch?v=ZSbdzZVQWnI SpeedTutor

namespace RiseReign
{
	public class Damageable : MonoBehaviour
	{
		ChopTree treeScript;
		ThirdPersonController playerControl;
		int rayLength = 5;
		[SerializeField]
		string playerName;		
		

		void Update()
		{
			RaycastHit hit;
			Vector3 forward = transform.TransformDirection( Vector3.forward );
			if( Physics.Raycast( transform.position, forward, hit, rayLength ))
			{
				if ( hit.collider.gameObject.tag == "tree" )
				{
					treeScript = GameObject.Find( hit.collider.gameObject.name ).GetComponent<ChopTree>();//Only finds the specific tree being chopped, ignores the others. USEFUL
					playerControl = GameObject.Find( playerName ).GetComponent<ThirdPersonController>();

					if( Input.GetButtonDown( "Fire1" ) && anim.swing == true ) //only while swinging the health can be affected. USEFUL
					{
						treeScript.treeHealth -= 10;
					}
				}
			}
		}
	}
}
