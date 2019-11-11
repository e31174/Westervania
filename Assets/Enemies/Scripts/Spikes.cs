using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : EnemyController {

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void getHit(Collider2D other)
    {
        GetComponent<AudioSource>().PlayOneShot(enemyDamage[Random.Range(0, numberOfSounds)]);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
