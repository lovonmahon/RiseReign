using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RiseReign
{
    //Attach to boat model.
    public class BoatController : Monobehaviour
    {
        [SerializeField]
        float turnSpeed = 1000f;
        float acceleration = 10f;

        Rigidbody rb;

        void Start()
        {
            rb = gameObject.GetComponent<RigidBody>();
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            rbody.addTorque(0f, h * turnSpeed * Time.deltaTime, 0f); //turning
            rbody.AddForce( transform.forward * v * acceleration * Time.deltaTime);//Moving forward

        }
        
    }
}
