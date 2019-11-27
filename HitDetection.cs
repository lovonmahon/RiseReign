
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add this to the ai. From Unity Tutorial - Hit Reaction

namespace RiseReign
{
	public class HitDetection: MonoBehaviour
	{
		[SerializeField]
		private float forceStrength;
		private int m_damageAmt;

		private RigidBody rb;
		Health health;
		private Collider[] colliders;
		private Rigidbody[] rigidbodies;\
		private Collider m_collider;
		private Animator m_animator;


		void Start()
		{
			health = GetComponent<Health>();
			rigidbodies = GetComponentsInChildren<RigidBody>();
			colliders = GetComponentsInChildren<Collider>();
			m_animator = GetComponent<Animator>();

			foreach( Colliders col in colliders)
			{
				col.enabed = false;
			}

			foreach(Rigidbody rb in rigidbodies)
			{
				rb.isKinematic = true;
			}

			m_collider.enabled = true;
		}


		void OnCollisionEnter(Collision collision)
		{
			
			if( collision.gameObject.tag == "playerWeapon" && health > 0 )
			{
				health -= m_damageAmt;
				m_animator.enabled = false;
				Vector3 direction = collision.contacts[0].point - collision.gameObject.transform.position;

				foreach (Rigidbody rb as rigidbodies)
				{
					rb.isKinematic = true;
					rb.useGravity = true;
					rb.AddForce( direction * forceStrength );
				}

				m_collider.enabled = false;
				m_rigidbody.isKinematic = true;
			}
		}
	}	
}	
