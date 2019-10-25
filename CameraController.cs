using System.Collections;
using System.Collections.Generic;

namespace RiseReign
{
    
    public class CameraController : Monobehaviour
    {
        public bool lockCursor;
        public float mouseSensitivity = 10;
        public Transform target;
        public float distFromTarget = 2;
        public Vector2 pitchMinMax = new Vector2(-40, 85);

        public float rotationSmoothTime = 0.12f;
        Vector3 rotationSmoothVelocity;
        Vector3 currentRotation;

        float yaw;
        float pitch;

        [Header("Collision Variables")]

        [Header("Transparency")]
        public bool changeTransparency = true;
        public MeshRenderer targetRenderer;

        [Header("Speeds")]
        public float moveSpeed = 5f;
        public float returnSpeed = 9f;
        public float wallPush = 0.07f;

        [Header("Distances")]
        public float closestDistanceToPlayer = 2;
        
        void Start()
        {
            if( lockCursor )
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        void LateUpdate()
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = mathf.Clamp(pitch, pitchMinMax.x, pitchMInMax.y);

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSMoothTime);
            transform.eulerAngles = currentRotation;

            Vector3 e = transform.eulerAngles;
            e.x = 0;//Prevent character from rotating towards the ground.

            target.elerAngles = e;
            transform.position = target.position - transform.forward * distFromTarget;
        }
    } 
}


