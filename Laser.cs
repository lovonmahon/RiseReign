using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    float laserSpeed = 8.0f;
    bool _isEnemyLaser = false;
    Player _player;

           
    void Start() 
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("Player component not found");
        }
    }

    void Update()
    {
        if(_isEnemyLaser == false)
        {
            MoveUp();
        }
        else MoveDown();       
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * laserSpeed * Time.deltaTime);
        if(transform.position.y < -7.01)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);//Destroys both the parents and the children ojects.
            }
            Destroy(this.gameObject);
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
        if(transform.position.y >= 7.01)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);//Destroys both the parents and the children ojects.
            }
            Destroy(this.gameObject);
        }
    }
    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player.Damage();
        }
    }
}
