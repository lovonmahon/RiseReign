using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (Rigidbody))]

public class FloatingObjects : MonoBehaviour
{
    public float waterLevel = 0.0f;
    public float floatThreshold = 2.0f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;

    float forceFactor;
    Vector3 floatForce;

    void FixedUpdate()
    {
        forceFactor = 1.0f - ((reansform.position.y - waterLevel) / forceThreshold);

        if (forceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * GetComponent<RigidBody>().mass * (forceFactor - GetComponent<RigidBody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downForce, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
    }


}
