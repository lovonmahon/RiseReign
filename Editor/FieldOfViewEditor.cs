using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RiseReign;

//place this in an Editor folder in project
[CustomEditor(typeof (Sight))]//custom editor to visualize using the Sight script

public class FieldOfViewEditor : Editor
{
    // Start is called before the first frame update
    private void OnSceneGUI()
    {
        Sight sightRef = (Sight)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(sightRef.transform.position, Vector3.up, Vector3.forward, 360, sightRef.m_viewRadius)        ;

        Vector3 FOVAngleA = sightRef.DirectionFromAngle( -sightRef.m_viewAngle / 2, false);
        Vector3 FOVAngleB = sightRef.DirectionFromAngle( sightRef.m_viewAngle / 2, false);

        Handles.DrawLine( sightRef.transform.position, sightRef.transform.position + FOVAngleA * sightRef.m_viewRadius );
        Handles.DrawLine( sightRef.transform.position, sightRef.transform.position + FOVAngleB * sightRef.m_viewRadius );

        Handles.color = Color.red;
        foreach( Transform visibleTarget in sightRef.m_visibleTargets )
        {
            Handles.DrawLine( sightRef.transform.position, visibleTarget.position );
        }
    }
}
