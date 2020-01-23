using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign{
	
	public class AIPickup: MonoBehaviour{

	public Transform item, itemEquip, itemUnequip;
	public bool item_is_equipped;
	
	void Update(){
		if(item_is_equipped)
		{
			GetComponent<BoxCollider>().enabled = false;
			GetComponent<Rigidbody>().useGravity = false;
			item.position = itemEquip.position;
			item.rotation = itemEquip.rotation;
		}
		else
		{
			GetComponent<BoxCollider>().enabled = true;
			GetComponent<Rigidbody>().useGravity = true;
			item.position = itemUnequip.position;
			item.rotation = itemUnequip.rotation;
		}
	}
	
	public void itemEquipped()
	{
		item_is_equipped = true;
	}
	
	public void itemUnequipped()
	{
		item_is_equipped = false;
	}
}
}
