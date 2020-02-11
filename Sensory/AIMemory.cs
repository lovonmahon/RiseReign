using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Learned from RPG Core

public class AIMemory : MonoBehaviour
{
    [SerializeField] float suspicionTime = 10f;
    float timeSinceLastSawPlayer = Math.Infinity;
    Signt m_sight;
    public bool alert = false;

    //If the player is spotted, timeSinceLastSawPlayer = 0;
    
    void Start()
    {
        m_sight = this.GetComponent<Sight>();
    }
    
    void Update()
    {
        if( m_sight.m_canSeePlayer == true )
        {
            timeSinceLastSawPlayer = 0;
        }
        
        if ( timeSinceLastSawPlayer < suspicionTime )
        {
            alert = true;
        }
       
        alert = false;
        timeSinceLastSawPlayer += Time.deltaTime;

    }
}
