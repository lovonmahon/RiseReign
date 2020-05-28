using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();//Make sure only one instance of the GWorld is accessed. This is a singleton
    private static WorldStates world;//Dictionary to hold world states.
    private static Queue<GameObject> patients;//patients will add themselves to the queue so the nurse can treat them
    

    static GWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
    }

    private GWorld()
    {}

    public void AddPatient(GameObject p) 
    {
        patients.Enqueue(p);
    }
    
    public GameObject RemovePatient()
    {
        if(patients.Count == 0) return null;//no patients in queue, so return null list
        return patients.Dequeue();
    }

    public static GWorld Instance//can be accessed using a singleton.
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;//return th status of the world.
    }
}
