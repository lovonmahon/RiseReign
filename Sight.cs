Ray lastRay;
int los = 20;// Line of sight.

//use this for long range chasing or evasion.

void spotTarget()


RaycastHit hit;//stores hits 
float theDistance;//stores the distance of what was hit

Vector3 forward = transform.TransformDirection(Vector3.forward) * los; //generates ray from origin in the forward direction of length los.
Debug.DrawRay(transform.position, forward, COlor.red);//disable debugging in production.


//now check what was hit and where it is located.

if(Physics.Raycast(transform.position, (forward), out hit ))
{
	//store the location in theDistance 
	theDistance = hit.distance;
}

void Update()
{
	spotTarget();
}
