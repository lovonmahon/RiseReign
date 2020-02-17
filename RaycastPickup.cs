using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Inventory collect for player

public class RaycastPickup : MonoBehaviour
{
	Inventory inventory;
	
	int rayLength = 5;
	LayerMask mask = -1// Hits only objects in the layer 1

	void Start()
	{
		inventory = this.GetComponent<Inventory>();
	}

	void Update()
	{
		RaycastHit hit;

		if( Physics.Raycast( transform.position, transform.TransformDirection( Vector3.forward) * rayLength, out hit, mask.value  )
		{
			//Repeat the if condition below as needed to add different items to inventory.
			if( hit.collider.gameObject.tag == "fish" )
			{
				//guiShow = true;//handle gui later.
				if( Input.GetKeyDown("e") )
				{
					inventory.fish++;
					Destroy( hit.collider.gameObject );
					//guiShow = false;
				}
			}
		}
	}
}
