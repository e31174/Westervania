using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSkull : EnemyController {

    public bool gravityOn = false; 

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if (collider.tag == "EnemyBullet") return;
        getHit(collider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Ground")
        {
            damage = 0;
            GetComponent<AudioSource>().PlayOneShot(enemyDamage[Random.Range(0, numberOfSounds)]);
            Destroy(gameObject, .2f);
        }
    }
    // Update is called once per frame
    protected override void Update () {

        if (gravityOn == true)
        {
            Rigidbody2D skull = GetComponent<Rigidbody2D>();
            skull.gravityScale = 1.5f;
        }
	}

    public override void getHit(Collider2D other)
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
            gravityOn = true;
        }
    }
}
