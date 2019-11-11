using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSkullTrigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GetComponentInParent<AudioSource>().PlayOneShot(GetComponentInParent<FallingSkull>().enemyDamage[Random.Range(0, GetComponentInParent<FallingSkull>().numberOfSounds)]);
            GetComponentInParent<FallingSkull>().gravityOn = true;
        }
    }
}
