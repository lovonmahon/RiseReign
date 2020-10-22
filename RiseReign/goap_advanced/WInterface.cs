using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInterface : MonoBehaviour
{
    GameObject focusObj;
    public GameObject newResourcePrefab;
    Vector3 goalPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);//Ray from the center screeen to the position of the mouse
            if(!Physics.Raycast(ray, out hit))
                return;
            goalPos = hit.point;
            focusObj = Instantiate(newResourcePrefab, goalPos, newResourcePrefab.transform.rotation);
        }
    }
}
