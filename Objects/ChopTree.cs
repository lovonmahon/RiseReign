using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign
{
	//Add this script to cuttable trees.
	public class ChopTree : MonoBehaviour
	{
		Transform[] logs;
		GameObject tree;
		Rigigbody rb;
		int treeHealth = 100;
		GameObject player;
		int speed = 2;

		void Start()
		{
			tree = this.gameObject;
			rb.GetComponent<RigidBody>().isKinematic = true;//will NOT be affected by physics, only by transform.
			player = GameObject.FindWithTag("Player");
		}

		void Update()
		{
			Vector3 forceDir = this.transform.position + player.transform.position;
			if( treeHealth <= 0 )
			{
				rb.isKinematic = false;
				rb.AddForce( forceDir * speed, ForceMode.Force);
				DestroyTree();
			}
		}

		void DestroyTree()
		{
			yield WaitForSeconds(10);
			Destroy( tree );

			Vector3 position = Vector3( Random.Range( -1.0, 1.0), 0, Random.Range( -1.0, 1.0 ) );
			Instantiate( logs, tree.transform.position + Vector3( 0, 0, 0 ) + position, Quaternion.identity );//add a vector3 to tree and add randomness [position] to it
			Instantiate( logs, tree.transform.position + Vector3( 2, 2, 0 ) + position, Quaternion.identity );//change number to suit.
			Instantiate( logs, tree.transform.position + Vector3( 5, 5, 0 ) + position, Quaternion.identity );//change numbers to suit.
		}
	}
}
