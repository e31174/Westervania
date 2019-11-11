using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : EnemyController {

    [SerializeField] float attackRadius;
    [SerializeField] float followRadius;
    [SerializeField] float fireRate;
    [SerializeField] float bulletTimer;
    public Animator anim;
    public GameObject enemyBullet;
    private Rigidbody2D m_RigidBody;
    private Quaternion m_Quaternion;
    private bool onGround;
    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    void Awake()
    {
        m_GroundCheck = transform.Find("GroundCheck");
    }

    void FixedUpdate()
    {
        onGround = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                onGround = true;
        }
    }

    protected override void Update () {
        m_RigidBody = GetComponent<Rigidbody2D>();
        if (Vector2.Distance(transform.position, playerTransform.position) <= followRadius && Vector2.Distance(transform.position, playerTransform.position) >= attackRadius)
        {
            if (onGround)
            {
                Move();
            }
        }
        if (Vector2.Distance(transform.position, playerTransform.position) < attackRadius)
        {
            if (Time.time > bulletTimer)
            {
                GameObject instBullet = Instantiate(enemyBullet, new Vector3(m_RigidBody.position.x, m_RigidBody.position.y), Quaternion.identity) as GameObject;
                Vector2 targetDirection = playerTransform.position - transform.position;
                instBullet.GetComponent<EnemyBulletBehavior>().moveDirection = targetDirection;
                bulletTimer = Time.time + fireRate;
            }
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followRadius);

    }
    protected override void Move()
    {
        Vector2 direction = new Vector2((playerTransform.position.x - transform.position.x), 0);
        enemyBod.velocity = (direction.normalized * speed);
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
