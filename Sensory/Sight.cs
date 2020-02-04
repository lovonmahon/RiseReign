using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign {

	public class Sight : MonoBehaviour
	{
		private bool m_investigate = false;//Should agent investigate?

		[SerializeField]
		private float m_investigateRange = 5;//range in which to investigate


		private Vector3 m_playerLastKnownPosition;//last place player was spotted.
		public bool m_canSeePlayer = false;//can the agent see the player?


		[Range(0, 359)]
		public float m_viewAngle;//FOV

		public float m_viewRadius;//The view radius.
		public LayerMask m_obstacleMask;//What are obstacles?
		public LayerMask m_targetMask;//What are possible targets?
		public List<Transform> m_visibleTargets = new List<Transform>();//Create a list to store targets and construct it.

		[SerializeField]
		private GameObject m_alertSound;//any noise that will alert ai.

		private bool m_noiseAlert = false;

		//Start Coroutine to find targets.

		private void Start()
		{
			StartCoroutine( "FindTargets", 0.2f);//find targets every 0.2 seconds.
		}
		/// <param name="delay">How long to delay.</param>
		private IEnumerator FindTargets(float delay)
		{
            while( true)
			{
				yield return new WaitForSeconds( delay);
				FindVisibleTargets();//Method to loop through targets
			}
		}

		//Now calculate distances to objects and analyze whether they are valid targets or not.

		private void FindVisibleTargets()
		{
			m_visibleTargets.Clear();//Clear list before starting a new round
			m_canSeePlayer = false;//reset seeing the player

			//Create an array of objects to spherecast collide with to check them.
			Collider[] cTargetsInViewRadius = Physics.OverlapSphere( transform.position, m_viewRadius, m_targetMask );

			//Iterate the list. of targets in the view radius.
			for ( int i = 0; i < cTargetsInViewRadius.Length; i++ )
			{
				Transform target = cTargetsInViewRadius[i].transform;//Select the target as the current iteration to analyze.
				//Calculate direction to target.
				Vector3 dirToTarget = (target.position - transform.position).normalized;//ray ends at target.

				//Now calculate the angle the target is to the transform to see if in view	

				if( Vector3.Angle(transform.forward, dirToTarget) < m_viewAngle * 0.5f )
				{
					//Calculate distance to target now.

					float distanceToTarget = Vector3.Distance( transform.position, target.position);
					if( !Physics.Raycast( transform.position, dirToTarget, distanceToTarget, m_obstacleMask))//Is the target in range and not an obstacle?
					{
						//Add the target to list if it wasn't added already.
						m_visibleTargets.Add(target);

						if( target.CompareTag("Player"))//if target is the player..
						{
							m_canSeePlayer = true;
                            Debug.Log("Player spotted!");
							//this.GetComponent<Worker>.m_interrupt = true;//Interrupt current action.
							m_playerLastKnownPosition = target.transform.position;
							m_investigate = true;
						}
					}
				}
			}

			if ( !m_canSeePlayer )
			{
				if( m_investigate)
				{
					//this.GetComponent<Worker>.m_interrupt = true;
					m_investigate = true;
					m_canSeePlayer = false;
					//m_alertNoise = false; Implement noise later.

					//Also implement later calling for reinforcements (i.e another guard can see player).
				}
				
			}
		}
		/// <summary>
		/// Gets a direction vector from an angle in degrees;
		/// </summary>
		/// <param name="a_fAngleDegrees">The angle to turn into direction.</param>
		/// <param name="a_bGlobalAngle">if set to <c>true</c> [a b global angle].</param>
		/// <returns></returns>
		public Vector3 DirectionFromAngle(float a_fAngleDegrees, bool a_bGlobalAngle)
		{
			if (!a_bGlobalAngle)
			{
				a_fAngleDegrees += transform.eulerAngles.y;
			}
			return new Vector3(Mathf.Sin(a_fAngleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(a_fAngleDegrees * Mathf.Deg2Rad));
		}
	}
}		
