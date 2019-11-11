using UnityEngine;
using System.Collections;

// Public is the first part of the class, optional modifier (abstract, virtual, etc.), class, then the name of it like EnemyController
public abstract class EnemyController : MonoBehaviour {
	// Protected is private except children can also access this variable
	[SerializeField] protected float speed;
	[SerializeField] protected int health;
	[SerializeField] protected int damage;
    [SerializeField] public int numberOfSounds;

	protected Transform playerTransform;
	protected Rigidbody2D enemyBod;
    protected float hurt = .1f;
    protected bool hit;
    protected int randomSound;

    [SerializeField] public AudioClip[] enemyDamage =  new AudioClip[0];
    

	void Start () {
        hit = false;
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		enemyBod = GetComponent<Rigidbody2D> ();
	}

	// get{} and set{} are shorthand for getters and setters for variables
	public int Health {
		// get the variable you want
		get{return health;}
		// set health equal to the value (value is a keyword)
		// the set is acting as 2 lines of code
		set{health = value; if (health <= 0) Die ();}
	}

	// This is the same as function OnTriggerEnter2D (Other: Collider2D)
	public virtual void OnTriggerEnter2D (Collider2D other){
        getHit(other);
	}

    public virtual void getHit(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);


            GetComponent<AudioSource>().PlayOneShot(enemyDamage[Random.Range(0, numberOfSounds)]);
            hit = true;
            Health--;
            if (hit == true)
            {
                GetHit();
            }

            else
            {
                NotHit();
            }

        }
        else if (other.tag == "Player")
        {
            DamagePlayer();
            Health--;
        }
    }

	 protected virtual void Die(){
		Destroy (gameObject);
	}

	// Virtual is used for overriding function.
	protected virtual void Move(){
		Vector2 direction = (playerTransform.position - transform.position);
		enemyBod.velocity = (direction.normalized * speed);
        if (enemyBod.velocity.x < 0)
        {
            GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
        }
        else {
            GetComponent<Transform>().eulerAngles = new Vector2(0, 0);
        }
    }

    protected void GetHit()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("NotHit", hurt);
    }

    protected void NotHit()
    {
        hit = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    protected virtual void DamagePlayer(){
		playerTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
	}

	protected virtual void Update () {
        Move ();
	}
}