//Incomplete script.
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

//the code below to be used as a separate class or place inside existing code to check left, right and forward directions.
/*
RaycastHit hit;

float theDist;
Vector3 forwardDist = transform.position, transform.TransformDirection(Vector3.forward) * 20;
Vector3 leftDist = transform.position, transform.TransformDirection(Vector3.left) * 20;
Vector3 rightdDist = transform.position, transform.TransformDirection(Vector3.right) * 20;

if(Physics.Raycast(transform.position, (forwardDist), out hit)
{
	if(hit.collider.tag == "player" && health > 30)
	{
		theDist = hit.distance;
	}
	
}

if(Physics.Raycast(transform.position, (leftDist), out hit)
{
	if(hit.collider.tag == "player" && health > 30)
	{
		theDist = hit.distance;
	}
}

if(Physics.Raycast(transform.position, (rightdDist), out hit)
{
	if(hit.collider.tag == "player" && health > 30)
	{
		theDist = hit.distance;
	}
}

agent.SetDestination(theDist);

*/
