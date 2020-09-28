using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;


    void Start()
    {
        //Start the player at position zero.
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //create a local variable for horizontal axis movement
        float horizontalInput = Input.GetAxis("Horizontal");
        //Vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        //Optimized input
        Vector3 direction = new Vector3(horizontalInput,verticalInput,0);
        transform.Translate(direction * _speed * Time.deltaTime);
        
        
        
    }
}
