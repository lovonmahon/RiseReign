using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WInterface : MonoBehaviour
{
    GameObject focusObj;
    public GameObject newResourcePrefab;
    Vector3 goalPos;
    public NavMeshSurface surface;
    public GameObject hospital;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Ray from the center screeen to the position of the mouse
            if(!Physics.Raycast(ray, out hit))
                return;
            goalPos = hit.point;
            focusObj = Instantiate(newResourcePrefab, goalPos, newResourcePrefab.transform.rotation);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            focusObj.transform.parent = hospital.transform;//must be parented to the gameobject that has the navmesh build script
            surface.BuildNavMesh();//dynamically rebuild navmesh for new objects placed.
            GWorld.Instance.GetQueue("toilets").AddResource(focusObj);//add the focusObject to the toilets queue(or any queue desired).
            GWorld.Instance.GetWorld().ModifyState("FreeToilet", 1);  //Make an additional toilet available.
        }
        else if(focusObj && Input.GetMouseButton(0))
        {
            RaycastHit hitMove;
            Ray rayMove = Camera.main.ScreenPointToRay(Input.mousePosition);//Ray from the center screeen to the position of the mouse
            if(!Physics.Raycast(rayMove, out hitMove))
                return;
        goalPos = hitMove.point;
        focusObj.transform.position = goalPos;
        }
    }
}
