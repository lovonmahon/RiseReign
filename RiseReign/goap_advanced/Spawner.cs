using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject patientPrefab;
    public int numPatients;//how many patient prefabs to spawn.
    //public int spawnDelay = 5;    
    public int minDelay = 2;
    public int maxDelay = 7;
    int spawned = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn", 5);
    }

    IEnumerator Spawn()//to avoid the for loop spawning all prefabs at once, have this function get called separately per round o floop.
    {
        for(int i = 0; i < numPatients; i++)        
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
            spawned++;
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));            
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //
    }
}
