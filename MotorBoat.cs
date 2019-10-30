using System;
using UnityEngine;

namespace RiseReign
{
    public class MotorBoat : MonoBehaviour
    {
        //Visible properties
        public Transform Motor;
        public float steerPower = 500f;
        public float power = 5f;
        public float maxSpeed = 10f;
        public float drag = 0.1f;

        //Components

        protected RigidBody rb;
        protected Quaternion startRotation;
        protected ParticleSystem particleSystem;
        
        void Awake()
        {
            rb = GetComponent<RigidBody>();
            startRotation = Motor.localRotation;
            particleSystem = GetComponent<ParticleSystem>();
        }

        void FixedUpdate()
        {
            //Default direction
            var forceDirection = transform.forward;
            var steer = 0;

            //steer direction
            if(Input.GetKey(KeyCode.A))
            {
                steer = 1;
            }

            if(Input.GetKey(KeyCode.D))
            {
                steer = -1;
            }

            //Rotational force
            rb.AddForceAtPosition( steer * transform.right * steerPower / 100f, Motor.position );

            //compute vectors - in case the model is facing a different direction, force is applies proportionally still.
            var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
            var targetVelocity = Vector3.zero;

            //forward/backward power
            if (Iput.GetKey(KeyCode.W))
            {
                PhysicsHelper.ApplyForceToReachVelocity(rb, forward * maxSpeed, power);
            }

            if (Iput.GetKey(KeyCode.S))
            {
                PhysicsHelper.ApplyForceToReachVelocity(rb, forward * -maxSpeed, power);
            }

            //Motor animation and particle system
            Motor.SetPositionAndRotation(Motor.position, transform.rotation * startRotation * Quaternion.Euler(0, 30f * steer, 0));
            if (particleSystem != null)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    particleSystem.Play();
                }
                else
                {
                    particleSystem.Pause;
                }
            }
    }
}
}

