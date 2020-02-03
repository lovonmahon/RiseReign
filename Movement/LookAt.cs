using UnityEngine;
using RiseReign;


//Look at target
public class LookAt : MonoBehaviour
{
	public Transform target;
	public float rotationSpeed;

	void Update()
	{
		Vector3 direction = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation( direction, Vector3.up);
		transform.rotation = Quaternion.Lerp( transform.rotation, rotation, rotationSpeed * Time.deltaTime );
	}
}
