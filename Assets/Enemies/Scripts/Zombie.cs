using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : EnemyController {

    [SerializeField] float movementRange;

    private float center;
    private float left;
    private float right;
    private int direction;

    // Use this for initialization
    void Awake() {
        center = transform.position.x;
        left = center - movementRange;
        right = center + movementRange;
        direction = -1;
    }

    // Update is called once per frame
    protected override void Update () {
        enemyBod.velocity = new Vector2(speed * direction, 0);
        if (transform.position.x < left)
            direction = 1;
        if (transform.position.x > right)
            direction = -1;

        if (enemyBod.velocity.x < 0)
        {
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
            // GetComponent<Transform>().
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
