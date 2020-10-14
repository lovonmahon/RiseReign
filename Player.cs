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
    GameObject tripleShotLaser;
    [SerializeField]
    float _fireRate = 0.5f;//wait time before allowing player to fire again.
    [SerializeField]
    int _lives = 3;
    [SerializeField]
    int _score = 0;
    private float _canFire = -0.1f;//to allow for first shoot
    SpawnManager spawnManager;

    Laser laser;
    [SerializeField]
    bool _isTripleShotActive = false;
    [SerializeField]
    bool _isSpeedBoostActive = false;
    [SerializeField]
    bool _isShieldActive = false;
    PowerUp powerUp;
    [SerializeField]
    GameObject _playerShield;
    
    UIManager _uiManager;

    void Start()
    {
        //Start the player at position zero.
        transform.position = new Vector3(0,0,0);
        laser = gameObject.GetComponent<Laser>();
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }

        if( _uiManager == null)
        {
            Debug.Log("UIManager component not found.");
        }
        
        _playerShield.SetActive(false);
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
        
        if( _isTripleShotActive == true )
        {
            Instantiate(tripleShotLaser, transform.position + new Vector3(-0.404f,0.012f,0f), Quaternion.identity);
            //powerUp.ShotsFired();
        }
        else Instantiate(laserPrefab, transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
    }


    public void Damage()
    {
        if(_isShieldActive == true)
        return;
        else _lives--;//Subtract one
        _uiManager.UpdateLives(_lives);//Update lives display on UI.

        if(_lives < 1)
        {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            //_uiManager.GameOver();
        }
    }

    public void AddScore(int points)
    {
        //Update Player score first.
        _score += points;
        //Then pass player score to UI
        _uiManager.UpdateScore(_score);
    }

    public void ActivateTripleshot()
    {
        
        StartCoroutine("TripleShotTime");
    }

    IEnumerator TripleShotTime()
    {
        if(_isTripleShotActive == false)
        {
            _isTripleShotActive = true;
            yield return new WaitForSeconds(5.0f);
            _isTripleShotActive = false;//Disable after 5 seconds
        }
        
    }

    public void ActivateSpeedBoost()
    {
        StartCoroutine("SpeedBoostTime");
    }

    IEnumerator SpeedBoostTime()
    {
        if(_isSpeedBoostActive == false)
        {
            _isSpeedBoostActive = true;
            _speed = 10.0f;
            yield return new WaitForSeconds(7.0f);
            _isSpeedBoostActive = false;
            _speed = 3.5f;
        }
        
    }

    public void ActivateShield()
    {
        StartCoroutine("ShieldTime");
    }

    IEnumerator ShieldTime()
    {
        if(_isShieldActive == false)
        {
            _isShieldActive = true;
            _playerShield.SetActive(true);
            yield return new WaitForSeconds(5.0f);
            _isShieldActive = false;
            _playerShield.SetActive(false);
        }
        
        
    }
}
