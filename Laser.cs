using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    float laserSpeed = 8.0f;

           
    // Update is called once per frame
    void Update()
    {
        Shoot();
        DestroyLaser();
    }

    public void Shoot()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
    }

    void DestroyLaser()
    {
        if(transform.position.y >= 7.01)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);//Destroys both the parents and the children ojects.
            }
            Destroy(this.gameObject);
        }
    }
}
