using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab;
    [SerializeField]
    GameObject _tripleShotPowerupPrefab;
    [SerializeField]
    GameObject _speedBoostPrefab;
    [SerializeField]
    GameObject _shieldPrefab;

    [SerializeField]
    float _top = 7.08f;
    [SerializeField]
    GameObject _enemyContainer;
    bool _stopSpawning = false;
    public void StartSpawning()
    {
        StartCoroutine("EnemySpawn", 2.0f);
        StartCoroutine("TripleShotPowerupSpawn", 2.0f);
        StartCoroutine("SpeedBoostPowerupSpawn", 5.0f);
        StartCoroutine("ShieldPowerupSpawn");
    }

  
    IEnumerator EnemySpawn()
    {
        //yield return null;//Wait for 1 frame
        yield return new WaitForSeconds(3.0f);//wait before spawning

        int numSpawned = 0;        
        while ( numSpawned < 75 && _stopSpawning == false )
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.29f), _top, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            //parent it to the spawn manager to keep hiererchy clean
            newEnemy.transform.parent = _enemyContainer.transform;
            numSpawned++;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator TripleShotPowerupSpawn()
    {
        yield return new WaitForSeconds(3.0f);//wait before spawning
        while( _stopSpawning == false )
        {
            Vector3 tripleshotPosToSpawn = new Vector3(Random.Range(-8.0f, 8.29f), _top, 0);
            GameObject newTripleShotPowerup = Instantiate(_tripleShotPowerupPrefab, tripleshotPosToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(35.0f, 50.0f));
        }
        
    }

    IEnumerator SpeedBoostPowerupSpawn()
    {
        yield return new WaitForSeconds(3.0f);//wait before spawning
        while( _stopSpawning == false )
        {
            Vector3 speedBoostPosToSpawn = new Vector3(Random.Range(-8.0f, 8.29f), _top, 0);
            GameObject newSpeedBoostPowerup = Instantiate(_speedBoostPrefab, speedBoostPosToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(30.0f, 60.0f));
        }
        
    }

    IEnumerator ShieldPowerupSpawn()
    {
        yield return new WaitForSeconds(3.0f);//wait before spawning
        while( _stopSpawning == false )
        {
            Vector3 shieldPosToSpawn = new Vector3(Random.Range(-8.0f, 8.29f), _top, 0);
            GameObject newShieldPowerup = Instantiate(_shieldPrefab, shieldPosToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(30.0f, 45.0f));
        }
        
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
