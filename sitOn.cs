using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Add this script to an object a character will sit on.  Use an empty, then place empty on actual sitting object to be able to adjust sitting position.

public class sitOn: MonoBehaviour{
	[SerializeField] moveSpeed;
	public GameObject character;
	Animator anim;
	bool isWalkingTowards = false;
	bool sittingOn = false;
	
	
	void OnMouseDown()
	{	
		if(!sittingOn)
		{
			anim.SetTrigger("isWalking");
			isWalkingTowards = true;
		}		
	}
	
	void Start()
	{	
		anim = character.GetComponent<Animator>();
	}
	
	void Update()
	{
		if(isWalkingTowards)
		{
			Vector3 targetDir;
			targetDir = new Vector3(transform.position.x - character.position.x, 0f, 
			transform.position.z - transform.position.z;//move character towards the target goal position.
			
			//Now rotate the character.
			Quaternion rot = Quaternion.LookRotation(teregetDir);//rot variable holds the rotation data to look at the target.
			character.transform.rotation = Quaternion.Slerp(character.transform.rotation, rot, 0.05f);//smooth rotation using slerp.
			//Now move the character forward along the z axis
			character.transform.Translate(Vector3.forward * moveSpeed);
			
			if(Vector3.Distance(character.transform.position, this.transform.position)<0.5)//compare the character and target position; are they close enough to each other for character to sit?
			{
				anim.SetTrigger("isSitting");
				//Now the character needs to turn and align to the sitting position.
				character.transform.roation = this.transform.rotation;
				//No longer walking, set bool to false.
				isWalkingTowards = false;
				sittingOn = true;
				
			}
		}
	}
}
