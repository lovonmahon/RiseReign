using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed = 3.0f;
    float _top = 7.08f;
    //[SerializeField]
    //GameObject _player;
    [SerializeField]
    Animator _anim;
    [SerializeField]
    AudioSource _audioExplosion;
    
    [SerializeField]
    GameObject _enemyLaser;
    float _canFire = -1.0f;
    [SerializeField]
    float _enemyFireRate = 1.0f;

    Player playerScript;

    void Start() {
        {
            playerScript = GameObject.Find("Player").GetComponent<Player>();
            if(playerScript == null)
            {
                Debug.LogError("No Player component found.");
            }
            _anim = GetComponent<Animator>();
            if(_anim == null)
            {
                Debug.LogError("Animator component not attached");
            }
            _audioExplosion = GameObject.Find("Explosion").GetComponent<AudioSource>();//Get the parented explosion game object.
            if(_audioExplosion == null)
            {
                Debug.LogError("The audio source is not found");
            }            
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Time.time > _canFire)
        {
            _enemyFireRate = Random.Range(1.0f, 2.0f);
            _canFire = Time.time + _enemyFireRate;
            _enemyLaser =  Instantiate(_enemyLaser, transform.position, Quaternion.identity);
            //Grab the laser component from each laser child
            Laser[] lasers = _enemyLaser.GetComponentsInChildren<Laser>();
            //Loop through the laser children and  have each laser component call the AssignEnemyLaser()
            for(int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -5.08f)
        {
            float randomX = Random.Range(-8.0f, 8.29f);
            transform.position = new Vector3(randomX, _top, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Hit "  + other.transform.name);
        if(other.tag == "Player")
        {
            //Null check to make sure component is not null...
            Player player = other.transform.GetComponent<Player>();
            if( player != null)
            {
                player.Damage();//call damage on player script
            }
            _anim.SetTrigger("onEnemyDeath");
            _audioExplosion.Play();
            _speed = 0f;//Stops trigger components from stil moving into the player to cause damage.
            Destroy(this.gameObject, 2.8f);
        }
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            _anim.SetTrigger("onEnemyDeath");
            _audioExplosion.Play();
            _speed = 0f;
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.0f);//Waits to allow the explode animation to play
            playerScript.AddScore(10);        
        }
    }
}
