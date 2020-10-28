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
    Vector3 clickOffset = Vector3.zero;
    bool offsetCalc = false;
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

                //reset
                offsetCalc = false;
                clickOffset = Vector3.zero;
            //Enable re-clicking on existing obj
            if(hit.transform.gameObject.tag == "RestRoom")
            {
                focusObj = hit.transform.gameObject;
            }
            else
            {
                goalPos = hit.point;
                focusObj = Instantiate(newResourcePrefab, goalPos, newResourcePrefab.transform.rotation);
            }
            focusObj.GetComponent<Collider>().enabled = false;//Disable the pickup from repeating while already holding the button down
        }
        else if(Input.GetMouseButtonUp(0))
        {
            focusObj.transform.parent = hospital.transform;//must be parented to the gameobject that has the navmesh build script
            surface.BuildNavMesh();//dynamically rebuild navmesh for new objects placed.
            
            GWorld.Instance.GetQueue("restrooms").AddResource(focusObj);//add the focusObject to the toilets queue(or any queue desired).
            GWorld.Instance.GetWorld().ModifyState("FreeToilet", 1);  //Make an additional toilet available.

            focusObj.GetComponent<Collider>().enabled = true;//Allow the pick up.
        }
        else if(focusObj && Input.GetMouseButton(0))
        {
            RaycastHit hitMove;
            Ray rayMove = Camera.main.ScreenPointToRay(Input.mousePosition);//Ray from the center screeen to the position of the mouse
            if(!Physics.Raycast(rayMove, out hitMove))
                return;

            if(!offsetCalc) 
            {
                clickOffset = hitMove.point - focusObj.transform.position;
                offsetCalc = true;
            }

            goalPos = hitMove.point - clickOffset;
            focusObj.transform.position = goalPos;
        }
        //Rotate the objects
        if(focusObj && (Input.GetKeyDown(KeyCode.Less) || Input.GetKeyDown(KeyCode.Comma)))
        {
            focusObj.transform.Rotate(0,90,0);
        }
        else if(focusObj && (Input.GetKeyDown(KeyCode.Greater) || Input.GetKeyDown(KeyCode.Period)))
        {
            focusObj.transform.Rotate(0,-90,0);
        }
    }
}
