using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign
{
	public class BuildingHealth : MonoBehaviour
	{
		[SerializeField]
		int damageAmt = 2;
		float fireDamageAmt = 0.6f;
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

		void OnTriggerStay( Collider other )
		{
			if( other.gameObject.tag == "Fire" )
			{
				TakeFireDamage( fireDamageAmt );//Set value in inspector.
			}
		}

		void OnTriggerExit( Collider other )
		{
			//
		}

		void TakeDamage( int damage ) //variable for argument
		{
			buildingHealth -= damage;			
		}

		void TakeFireDamage( float fdamage )
		{
			buildingHealth -= fdamage * Time.deltaTime;
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
