using UnityEngine;


public class equipUnequip: MonoBehaviour{

	public Transform Item, itemEquip, itemUnequip;
	public bool item_is_equipped;
	
	void Update(){
		if(item_is_equipped){
			item.position = itemEquip.position;
			item.rotation = itemEquip.rotation;
		}
		else{
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
			
