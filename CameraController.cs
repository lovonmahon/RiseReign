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

        public float rotationSmoothTime = 8f;
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
        public float closestDistanceToPlayer = 2f;
        public float evenCloserDistanceToPlayer = 1f;

        [Header("Mask")]
        public LayerMask collisionMask;

        private bool pitchLock = false;

        void Start()
        {
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        void LateUpdate()
        {
            CollisionCheck(target.position - transform.forward * distFromTarget);
            WallCheck();

            if (!pitchLock)
            {
                yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
                pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
                pitch = mathf.Clamp(pitch, pitchMinMax.x, pitchMInMax.y);
                currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);
            }
            else
            {
                yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
                pitch = pitchMinMax.y;
                currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);
            }

            transform.eulerAngles = currentRotation;

            Vector3 e = transform.eulerAngles;
            e.x = 0;//Prevent character from rotating towards the ground.

            target.elerAngles = e;

        }

        private void CollisionCheck(Vector3 retPoint)
        {
            RaycastHit hit;
            if (Physics.Linecast(traget.position, retpoint, out hit, collisionMask)) //start and end positions are known, so no need to raycast.
            {
                Vector3 norm = hit.normal * wallPush;
                Vector3 p = hit.point + norm;

                TransparencyCheck();
                if (Vector3.Distance(Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime), target.position) <= evenCloserDistanceToPlayer) //if close to player.
                {

                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime);
                }

                return;
            }

            FullTransparency();
            transform.position = Vector3.Lerp(transform.position, retPoint, returnSpeed * Time.deltaTime);
            pitchLock = false;
        }

        private void TransparancyCheck()
        {
            if (changeTransparency)
            {
                if (Vector3.Distance(transform.position, target.position) <= closestDistanceToPlayer)
                {
                    Color temp = targetRenderer.sharedMaterial.color;
                    temp.a = Mathf.lerp(temp.a, 0.2f, moveSpeed * Time.deltaTime); //Between 0.1-1 for color change

                    targetRenderer.sharedMaterial.color = temp;//only does this for one material.  Create a loop to iterate multiple materials

                }
                else
                {
                    if (targetRenderer.sharedMaterial.color.a <= 0.99f)
                    {
                        Color temp = targetRenderer.sharedMaterial.color;
                        temp.a = Mathf.lerp(temp.a, 1f, moveSpeed * Time.deltaTime);

                        targetRenderer.sharedMaterial.color = temp;
                    }
                }
            }
        }

        private void FullTransparency()
        {
            if (changeTransparency)
            {
                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.lerp(temp.a, 1f, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;
            }
        }

        private void WallCheck()
        {
            Ray ray = new Ray(target.position, -target.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.5f, out hit, 0.7f, collisionMask))
            {
                pitchLock = true;
            }
            else
            {
                pitchLock = false;
            }
        }
    }
}
