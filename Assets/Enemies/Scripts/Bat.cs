using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : EnemyController {

    [SerializeField] float attackRadius;
    [SerializeField] float dipAmount;
    [SerializeField] float flightSmoothness;


    private Animator m_Anim;
    private bool attack;
    private bool triggered;
    private float center;
    private float high;
    private float low;
    private float time;
    private bool reverse;

    private float startY;

    // Use this for initialization
    private void Awake () {
        m_Anim = GetComponent<Animator>();
        center = transform.position.x - dipAmount;
        attack = false;
        triggered = false;
        time = 0;
        reverse = false;
        startY = transform.position.y;
    }

    // Update is called once per frame
    protected override void Update() {
        if (attack && !reverse)
            time += Time.deltaTime;
        else if (reverse)
            time -= Time.deltaTime;
        if (attack && time >= flightSmoothness && !reverse)
        {
            time = flightSmoothness;
            reverse = !reverse;
        }
        else if (time <= 0 && reverse)
        {
            time = 0;
            reverse = !reverse;
        }
        if (Vector2.Distance(transform.position, playerTransform.position) < attackRadius)
        {
            attack = true;
        }
        m_Anim.SetBool("Attacking", attack);
        if (triggered)
        {
            Movement();
        }
        if (attack && !triggered)
            Attack();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

    void Attack()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyDamage[Random.Range(0, numberOfSounds)]);
        center = playerTransform.position.y;
        Vector2 m = new Vector2(0, startY);
        Vector2 n = new Vector2(startY, (startY - center - dipAmount) / 2 + center - dipAmount);
        Vector2 o = new Vector2(center, (startY - center) / 2 + center - dipAmount);
        Vector2 p = new Vector2(0, startY - center - dipAmount);
        Vector2 point = CalculateBezierPoint(time / flightSmoothness, m, n, o, p);
        enemyBod.velocity = new Vector2(playerTransform.position.x - transform.position.x, 0).normalized * speed;
        transform.position = new Vector2(transform.position.x, point.y);
        if (transform.position.y < center - dipAmount)
        {
            triggered = true;
            high = center + dipAmount;
            low = center - dipAmount;
            time = flightSmoothness;
            enemyBod.velocity = new Vector2(playerTransform.position.x - transform.position.x, 0).normalized*speed;
        }
    }

    void Movement()
    {
        Vector2 direction = new Vector2(0, (low - transform.position.y)).normalized;
        Vector2 point = CalculateBezierPoint(time / flightSmoothness, new Vector2(0, high), new Vector2((high - low) / 2 + low, high), new Vector2((high - low) / 2 + low, low), new Vector2(0, low));
        //Debug.Log(time);
        //enemyBod.velocity = new Vector2(enemyBod.velocity.x, (direction.y * speed));
        transform.position = new Vector2(transform.position.x, point.y);
    }

    Vector2 CalculateBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector2 p = uuu * p0; //first term
        p += 3 * uu * t * p1; //second term
        p += 3 * u * tt * p2; //third term
        p += ttt * p3; //fourth term

        return p;
    }
}
