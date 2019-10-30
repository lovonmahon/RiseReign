using System;
using UnityEngine;

namespace RiseReign
{
    
    public GameObject vehicle;
    public GameObject vehicleCam;
    public GameObject player;
    public GameObject playerStartPos;
    
    public class SwitchControl : MonoBehaviour
    {
        void Start(){}

        void Update()
        {
            //Vehicle mode
            if(Input.GetButton("mount"))
            {
                vehicle.GetComponent<RigidBody>().isKinematic = false;
                vehicle.GetComponent<BoatController>().enabled = true;
                vehicleCam.SetActive(true);

                //player.SetActive(false); this completely hides player

                player.GetComponent<ThirsPersonController>().enabled(false);//this only disables player control but character still visible
            }

            if(Input.GetButton("dismount"))
            {
                vehicle.GetComponent<RigidBody>().isKinematic = true;
                vehicle.GetComponent<BoatController>().enabled = false;
                vehicleCam.SetActive(false);

                //player.SetActive(true);

                player.GetComponent<ThirsPersonController>().enabled(true);
            }
    }
}
}

