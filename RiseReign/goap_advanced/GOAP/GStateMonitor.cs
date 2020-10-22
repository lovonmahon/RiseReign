using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Add to agents who will drop a resource in the environment.
public class GStateMonitor : MonoBehaviour
{
    public string state;
    public float stateStrength;
    public float stateDecayRate;
    public WorldStates beliefs;//Monitor beliefs
    public GameObject resourcePrefab;
    public string queueName;
    public string worldState;
    public GAction action;
    bool stateFound = false;
    float initialStrength;

    void Awake()
    {
        beliefs = this.GetComponent<GAgent>().beliefs;
        initialStrength = stateStrength;
    }

    // Update is called once per frame
    void LateUpdate()//only once
    {
        if(action.running)
        {
            stateFound = false;
            stateStrength = initialStrength;
        }
        if(!stateFound && beliefs.HasState(state))
            stateFound = true;

        if(stateFound)
        {
            stateStrength -= stateDecayRate * Time.deltaTime;
            if(stateStrength <= 0)
            {
                //where in location to the agent should the resource appear
                Vector3 location = new Vector3(this.transform.position.x, resourcePrefab.transform.position.y,this.transform.position.z);
                GameObject p = Instantiate(resourcePrefab, location, resourcePrefab.transform.rotation);
                stateFound = false;
                stateStrength = initialStrength;
                beliefs.RemoveState(state);
                GWorld.Instance.GetQueue(queueName).AddResource(p);
                GWorld.Instance.GetWorld().ModifyState(worldState, 1);//Agent will spawn a free resource into environment
            }
        }
    }

}
