using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceQueue
{
    public Queue<GameObject> que = new Queue<GameObject>();
    public string tag;
    public string modState;

    public ResourceQueue(string t, string ms, WorldStates w)
    {
        tag = t;
        modState = ms;
        if(tag != "")
        {
            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
            foreach(GameObject r in resources)
                que.Enqueue(r);
        }

        if(modState != "")
        {
            w.ModifyState(modState, que.Count);
        }
    }

    public void AddResource(GameObject r)
    {
        que.Enqueue(r);
    }

    public GameObject RemoveResource()
    {
        if(que.Count == 0) return null;
        return que.Dequeue();
    }
}

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();//Make sure only one instance of the GWorld is accessed. This is a singleton
    private static WorldStates world;//Dictionary to hold world states.
    private static ResourceQueue patients;//patients will add themselves to the queue so the nurse can treat them
    private static ResourceQueue cubicles;
    private static ResourceQueue offices;
    private static ResourceQueue restrooms;
    private static ResourceQueue puddles;
    private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();

    static GWorld()
    {
        world = new WorldStates();
        patients = new ResourceQueue("","",world);//patients will be added when they register at hospital
        resources.Add("patients", patients);//search the patients by string
        cubicles = new ResourceQueue("Cubicle","FreeCubicle",world);//Tag, current state, world state
        resources.Add("cubicles", cubicles);//search the cubicles by string
        offices = new ResourceQueue("Office","FreeOffice",world);//Tag, current state, world state
        resources.Add("offices", offices);//search the offices by string
        restrooms = new ResourceQueue("RestRoom","FreeRestroom",world);//Tag, current state, world state
        resources.Add("restrooms", restrooms);//search the restrooms by string
        puddles = new ResourceQueue("Puddle", "FreePuddle",world);
        resources.Add("puddles", puddles);

        
        Time.timeScale = 5;//This speeds up the world scene for testing.  Disable for production.
    }

    public ResourceQueue GetQueue(string type)
    {
        return resources[type];
    }

    private GWorld()
    {}
    //add patient
    
    public static GWorld Instance//can be accessed using a singleton.
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;//return th status of the world.
    }
}
