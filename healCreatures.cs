



Animator anim;
EnemyHealth health;


void Start()
{
	health = this.GetComponent<EnemyHealth>();
	anim = this.GetComponentInChildren<Animator>();
}



void OnTriggerEnter(Collider other)
{
	if(other.tag == "enemy")
	{
		anim = SetTrigger("heal");
		health.currentHealth = 100;
	}
}
