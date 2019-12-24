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
			//
		}

		public void TakeDamage( int damage )
		{
			helt -= damage; //loses damage amount from helt.
		}
	}
}
