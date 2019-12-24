using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign{
	

	//generic weapon class.
	//Set the damage based on the weapon type.

	
	public class Weapon : MonoBehaviour
	{
		public int damageAmount;
		Health health;

		void Start()
		{
			health = this.GetComponent<Health>();
		}

		void Update()
		{
			//
		}

		void OnTriggerEnter( Collider other)
		{
			if ( anim.SetTrigger( "attack", true ) && other.GameObject.FindWithTag("Player"))
			{
				health.TakeDamage( damageAmount );
			}
		}
	}
}
