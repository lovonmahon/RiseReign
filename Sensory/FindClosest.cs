using System.COllections;
using System.COllections.Generic;
using UnityEngine;

namespace RiseReign
{
	public class FindClosest : MonoBehaviour
	{
		public GameObject attackTarget;

		void Update()
		{
		FindClosestEnemy();
		}
	}

	void FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;//calculate the distance wherever they are
		Enemy closestEnemy = null;//clear the enemy list
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>(); //get al game objects with the enemy class(just an empty enemy component will do).

		foreach( Enemy currentEnemy in allEnemies )
		{
			//First, calculate distance to current enemy
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;

			//Analyze distance.
			if( distanceToEnemy < distanceToClosestEnemy )
			{
				distanceToClosestEnemy = distanceToEnemy;//update the distanceToClosestEnemy with the new distance value.
				closestEnemy = currentEnemy;//currentEnemy is no longer null, there is a target.

				attackTarget = closestEnemy;//feed this to the goap AttackAction ;) hehehe
			}
		}
	}
}


