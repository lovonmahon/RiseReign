using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed = 4.0f;
    float _top = 7.08f;
    [SerializeField]
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
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

    void OnTriggerEnter(Collider other) 
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
            Destroy(this.gameObject);
        }
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
