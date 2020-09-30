using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    float _fireRate = 0.5f;//wait time before allowing player to fire again.
    private float _canFire = -0.1f;//to allow for first shoot

    Laser laser;


    void Start()
    {
        //Start the player at position zero.
        transform.position = new Vector3(0,0,0);
        laser = gameObject.GetComponent<Laser>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            ShootLaser();
        }
    }

    void CalculateMovement()
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

        //Clamp y position to stay within range
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.29f, 0), 0);
        
        if(transform.position.x >= 11.30f)
        {
            transform.position = new Vector3(-11.22f, transform.position.y, 0);
        }
        else if(transform.position.x <= -11.34f)
        {
            transform.position = new Vector3(11.30f, transform.position.y, 0);
        }
    }

    void ShootLaser()
    {
        _canFire = Time.time + _fireRate;//update last time fire key was pressed.
        Instantiate(laserPrefab, transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
    }
}
