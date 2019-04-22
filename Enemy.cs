using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour, IGoap {

	public Animator animator;
	public Rigidbody rigidBody;
	public BoxCollider boxCollider;
	public PlayerMovement player;
	public BackpackComponent backpack;
	
    	public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    	public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    	public AudioClip deathClip;                 // The sound to play when the enemy dies.

	  
    	AudioSource enemyAudio;                     // Reference to the audio source.
    	ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    	CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    	bool isDead;                                // Whether the enemy is dead.
    	bool isSinking;                             // Whether the enemy has started sinking through the floor.
	
	public int health;
	public int strength;
	public int speed;
	public float stamina;
	public float regenRate;
	protected float terminalSpeed;
	protected float initialSpeed;
	protected float acceleration;
	protected float minDist = 1.5f;
	protected float aggroDist = 5f;
	protected bool loop = false;
	protected float maxStamina;

	// Use this for initialization
	void Start ()
	{
		if (backpack == null)
			backpack = gameObject.AddComponent ("BackpackComponent" ) as BackpackComponent;
		if (backpack.tool == null) {
			GameObject prefab = Resources.Load<GameObject> (backpack.toolType);
			GameObject tool = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
			backpack.tool = tool;
			tool.transform.parent = transform; // attach the tool
		}
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (stamina <= maxStamina) {
			Invoke ("passiveRegen", 1.0f);
		} else {
			stamina = maxStamina;
		}
		
		if(currentHealth <= 0)
        	{
            	// ... the enemy is dead.
            		Death ();
        	}
	}

	public virtual void passiveRegen();
	
   public virtual void TakeDamage (int amount, Vector3 hitPoint)
    {
        // If the enemy is dead...
        if(isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        enemyAudio.Play ();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
            
        // Set the position of the particle system to where the hit was sustained.
        hitParticles.transform.position = hitPoint;

        // And play the particles.
        hitParticles.Play();

        // If the current health is less than or equal to zero...
        
    }


    public virtual void Death ()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        anim.SetTrigger ("Dead");
	GetComponent<NavMeshAgent>.disable;

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public virtual void StartSinking ()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent <NavMeshAgent> ().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent <Rigidbody> ().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // Increase the score by the enemy's score value.
        ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy (gameObject, 2f);
    }

	public HashSet<KeyValuePair<string, object>> getWorldState(){
		HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>> ();
		worldData.Add (new KeyValuePair<string, object> ("damagePlayer", false)); //to-do: change player's state for world data here
		worldData.Add (new KeyValuePair<string, object> ("evadePlayer", false));
		worldData.Add(new KeyValuePair<string, object>("hasFishingRod", (inv.fishingRod > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasWheat", (inv.Wheat > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBakes", (inv.Bakes > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBakingFlour", (inv.wheatLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasRawFlour", (inv.breadLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasMeat", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasFish", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasHerbs", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasBerries", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasManure", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasHammer", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasPlanks", (inv.breadLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasWeapon", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasNails", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasCoins", (inv.breadLevel > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasTrap", (inv.breadLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasAnimalCaught", (inv.breadLevel > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasCocoaBallsocoaBalls", (inv.cocoaBalls > 4) ));
		worldData.Add(new KeyValuePair<string, object>("hasCocoaTea", (inv.cocoaBalls > 1) ));
		worldData.Add(new KeyValuePair<string, object>("hasOre", (backpack.numOre > 0) ));
		worldData.Add(new KeyValuePair<string, object>("hasLogs", (backpack.numLogs > 0) ));
		worldData.Add(new KeyValuePair<string, object>("hasFirewood", (backpack.numFirewood > 0) ));
		worldData.Add(new KeyValuePair<string, object>("hasTool", (backpack.tool != null) ));
		
		return worldData;
	}

	public abstract HashSet<KeyValuePair<string, object>> createGoalState ();
	
	
	public void planFailed (HashSet<KeyValuePair<string, object>> failedGoal){
		
	}

	public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GOAPAction> action){

	}

	public void actionsFinished(){
		
	}

	public void planAborted(GOAPAction aborter){

	}

	public void setSpeed(float val){
		terminalSpeed = val / 10;
		initialSpeed = (val / 10) / 2;
		acceleration = (val / 10) / 4;
		return;
	}

	public virtual bool moveAgent(GOAPAction nextAction){
		float dist = Vector3.Distance (transform.position, nextAction.target.transform.position);
		if (dist < aggroDist) {
			Vector3 moveDirection = player.transform.position - transform.position;

			setSpeed (speed);

			if (initialSpeed < terminalSpeed) {
				initialSpeed += acceleration;
			}

			Vector3 newPosition = moveDirection * initialSpeed * Time.deltaTime;
			transform.position += newPosition;
		}
		if(dist <= minDist) {
			nextAction.setInRange(true);
			return true;
		} else {
			return false;
		}
	}
}
