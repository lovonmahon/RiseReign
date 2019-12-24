using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign{
	
	public class Health : MonoBehaviour
	{
		public int helt = 100;

		void Start()
		{
			//
		}

		void Update()
		{
			if( helt <= 0 )
			{
				helt = 0;
				Die();
			}
		}

		public void TakeDamage( int damage )
		{
			helt -= damage; //loses damage amount from helt.
		}

		public void Die()
		{
			//Grab some components and disable them first.
			//Enable ragdoll.
			//Spawn bones/artifacts procedurally.
		}
	}
}
