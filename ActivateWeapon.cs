
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add this to the ai. From Unity Tutorial - Hit Reaction

namespace RiseReign
{
	public class ActivateWeapon
	{
		private Animator m_animator;
		public GameObject m_weapon;
		public AudioSource m_audio;

		bool m_audioPlay;
		bool m_audioStop;


		void Start()
		{
			m_animator = GetComponent<Animator>();
			m_audio = GetComponent<AudioSource>();
			m_audioPlay = false;
			m_audioStop = true;
		}


		void Update()
		{
			if( Input.GetMouseButtonDown(0))
			{
				m_animator.SetTrigger("attack");
			}
		}

		void enableWeapon()
		{
			m_weapon.GetComponent<Collider>.enable = true;
			m_audioPlay = true
			m_audio.Play();
			m_audioStop = false;
		}

		void disableWeapon()
		{
			m_weapon.GetComponent<Collider>.enable = false;
		}

		void attackBawl()
		{
			if ( m_audioPlay = true && m_audioStop = false )
			{
				m_audio.Stop();
			}
		}

	}	
}	
