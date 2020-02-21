using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign
{
	public class DayNightCycle : MonoBehaviour
	{
		[SerializeField]Light sun;
		[SerializeField] float secondsInFullDay = 100f;

		//create a slider in inspector.
		[Range(0,1)][SerializeField] float currentTime = 0;
		[SerializeField] float timeMultiplier = 1f;
		[SerializeField] float sunInitialIntensity;

		void Start()
		{
			sunInitialIntensity = sun.intensity;//Get the initial intensity of the sun.
		}

		void Update()
		{
			UpdateSun();

			currentTime += ( Time.deltaTime / secondsInFullDay ) * timeMultiplier;

			if( currentTime >= 1 )
			{
				currentTime = 0;
			}
		}

		void UpdateSun()
		{
			sun.transform.localRotation = Quaternion.Euler( ( currentTime * 360f ) - 90, 170, 0 );
		}
	}

}
