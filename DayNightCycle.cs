using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Based on SpeedTutor https://www.youtube.com/watch?v=MOuS2Wuntl8 (Based on twiik.net article Simplest possible day night cycle in Unity 5)
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
			
			//Sun's rotation
			sun.transform.localRotation = Quaternion.Euler( ( currentTime * 360f ) - 90, 170, 0 );//rotates 360, but uses a cutoff at 90x for horizon and 170y for same purpose.

			//Control fading.
			float intensityMultiplier = 1;

			if( currentTime <= 0.23f || currentTime >= 0.75f ) //before sunrise or sunset.
			{
				intensityMultiplier = 0;
			}

			else if( currentTime <= 0.25f )
			{
				intensityMultiplier = Mathf.Clamp01(( currentTime - 0.23f ) * 1/ 0.02f ) );
			}

			else if( currentTime >= 0.73f ) 
			{
				intensityMultiplier = Mathf.Clamp01( 1 - (( currentTime - 0.73f ) * ( 1 / 0.02f) ));
			}

			sun.intensity = sunInitialIntensity * intentisyMultiplier;
		}
	}

}
