﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();//Make sure only one instance of the GWorld is accessed. This is a singleton
    private static WorldStates world;//Dictionary to hold world states.
    private static Queue<GameObject> patients;//patients will add themselves to the queue so the nurse can treat them
    private static Queue<GameObject> cubicles;
    private static Queue<GameObject> offices;

    static GWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();
        offices = new Queue<GameObject>();

        //grab all cubicles in the world
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach(GameObject c in cubes)
            cubicles.Enqueue(c);
        //If there is a cubicle object, make one available in the world state so agent can use it.
        if(cubes.Length > 0)
            world.ModifyState("FreeCubicle", cubes.Length);//agent isn't modifying this state, the world is(global).  It can be used as a precondition.

        //grab all offices in the world
        GameObject[] offs = GameObject.FindGameObjectsWithTag("Office");
        foreach(GameObject o in offs)
            offices.Enqueue(o);
        //If there is a office object, make one available in the world state so agent can use it.
        if(offs.Length > 0)
            world.ModifyState("FreeOffice", offs.Length);//agent isn't modifying this state, the world is(global).  It can be used as a precondition.
        
        Time.timeScale = 5;//This speeds up the world scene for testing.  Disable for production.
    }

    private GWorld()
    {}
    //add patient
    public void AddPatient(GameObject p) 
    {
        patients.Enqueue(p);
    }
    //remote patient
    public GameObject RemovePatient()
    {
        if(patients.Count == 0) return null;//no patients in queue, so return null list
        return patients.Dequeue();
    }

    //add cubicle
    public void AddCubicle(GameObject c) 
    {
        cubicles.Enqueue(c);    
    }

    //remove cubible from list
    public GameObject RemoveCubicle()
    {
        if(cubicles.Count == 0) return null;//no cubicles in queue, so return null list
        return cubicles.Dequeue();
    }

    //add office
    public void AddOffice(GameObject o) 
    {
        offices.Enqueue(o);    
    }

    //remove office from list
    public GameObject RemoveOffice()
    {
        if(offices.Count == 0) return null;//no offices in queue, so return null list
        return offices.Dequeue();
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