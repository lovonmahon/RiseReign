using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();//Make sure only one instance of the GWorld is accessed. This is a singleton
    private static WorldStates world;//Dictionary to hold world states.
    

    static GWorld()
    {
        world = new WorldStates();
    }

    private GWorld()
    {}

    public static GWorld Instance//can be accessed using a singleton.
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;//return th status of the world.
    }
}
