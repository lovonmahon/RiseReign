using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign
{
	public class BuildingHealth : MonoBehaviour
	{
		[SerializeField]
		int damageAmt = 2;
		int buildingHealth = 100;

		bool canBuild = false;

		void Start()
		{
			//
		}

		void Update()
		{
			//
		}

		void OnTriggerEnter(Collider other)
		{
			if( other.gameObject.tag == "SiegeWeapon" )
			{
				TakeDamage( damageAmt );//Set value in inspector.
			}
		}

		void TakeDamage( int damage ) //variable for argument
		{
			buildingHealth -= damage;			
		}

		void CollapseStructure()
		{
			if (buildingHealth <= 0 )
			{
				buildingHealth = 0;
				/* Destroy current Game Object and Spawn destroyed prefab.
				GameObject.SetActive( false );
				Instantiate( destroyed );
				canBuild = true;
				*/
			}
			else canBuild = false;
		}
	}
}
