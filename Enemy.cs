using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed = 4.0f;
    float _top = 7.08f;
    //[SerializeField]
    //GameObject _player;
    [SerializeField]
    Animator _anim;
    [SerializeField]
    AudioSource _audioExplosion;
   

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
            Destroy(this.gameObject, 2.0f);//Waits to allow the explode animation to play
            playerScript.AddScore(10);        
        }
    }
}
