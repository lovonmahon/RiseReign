using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    float _rotationSpeed;
    [SerializeField]
    GameObject _asteroidExplosion;
    SpawnManager _spawnManager;
    [SerializeField]
    AudioSource _audioExplosion;
    [SerializeField]
    GameObject _infoText;
   
void Start() 
{
    _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    if(_spawnManager == null)
    {
        Debug.LogError("No SpanManager component found.");
    }
    _infoText.SetActive(true);

}

 
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Instantiate(_asteroidExplosion, transform.position, Quaternion.identity);
            _audioExplosion.Play();
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
            _infoText.SetActive(false);
        }
    }
}
