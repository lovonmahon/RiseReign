using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign{
	
	public class Health : MonoBehaviour
	{
		public int currentHealth = 100;

		void Start()
		{
			//
		}

		void Update()
		{
			if( currentHealth <= 0 )
			{
				currentHealth = 0;
				Die();
			}
			
			if( currentHealth > 100 )
			{
				currentHealth = 100;
			}	
		}

		public void TakeDamage( int damage )
		{
			currentHealth -= damage; //loses damage amount from helt.
		}

		public void Die()
		{
			//Grab some components and disable them first.
			//Enable ragdoll.
			//Spawn bones/artifacts procedurally.
		}
		
		void Recover()
		{
			int need = 100 - currentHealth;//calculate how much is needed to raise health back to 100%
			currentHealth = need += currentHealth;//take the needed amount and add it to the current health value.
		}
	}
}
