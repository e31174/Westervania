using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

    protected Transform playerTransform;
    protected GameObject target;

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerTransform.position = new Vector3(-16.64f, 18.06f, 0);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
