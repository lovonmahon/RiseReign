using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField]
    float __powerUpPickupSpeed;
    //[SerializeField]
    //int _tripleShotsAvailable = 2;
    
    [Header("Powerup Type")]
    [Tooltip("0-3 for tripleshot, speed boost or shield")]
    [SerializeField]
    int _powerUpType = 0;
    
    Player _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("'Player' component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * __powerUpPickupSpeed * Time.deltaTime);
        if(transform.position.y < -5.73f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            switch(_powerUpType)
            {
                case 0: 
                    _player.ActivateTripleshot();
                    break;
                case 1:
                    _player.ActivateSpeedBoost();
                    break;
                case 2:
                    _player.ActivateShield();
                    break;
                default:
                    Debug.Log("Ability error");
                    break;
            }
            
        }
    }

    /*public void  ShotsFired()
    {
        _tripleShotsAvailable--;
        if( _tripleShotsAvailable <= 0)
        {
            _player.DeactivateTripleShot();
        }
    }*/
}
