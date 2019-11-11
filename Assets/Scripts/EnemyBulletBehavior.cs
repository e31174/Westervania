using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{

    private Transform m_transform;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    public Vector2 moveDirection;
    protected Transform playerTransform;
    
    // Use this for initialization
    void Start()
    {
        m_transform = GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.rotation = Quaternion.FromToRotation(transform.right, moveDirection.normalized);
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Enemy" && collider.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Player")
        {
            playerTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
