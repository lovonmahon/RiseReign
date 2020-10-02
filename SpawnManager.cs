using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab;
    [SerializeField]
    float _top = 7.08f;
    [SerializeField]
    GameObject _enemyContainer;
    bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine("Spawn", 2.0f);
    }

   void Update() 
   {

   }


    IEnumerator Spawn()
    {
        //yield return null;//Wait for 1 frame

        int numSpawned = 0;        
        while ( numSpawned < 5 && _stopSpawning == true)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.29f), _top, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            //parent it to the spawn manager to keep hiererchy clean
            newEnemy.transform.parent = _enemyContainer.transform;
            numSpawned++;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
