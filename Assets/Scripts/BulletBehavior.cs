using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    private Transform m_transform;
    private enum Direction
    {
        NORTH,
        NORTHEAST,
        EAST,
        SOUTHEAST,
        SOUTH,
        SOUTHWEST,
        WEST,
        NORTHWEST
    };
    private Direction direction;
    // Use this for initialization
    void Start () {
        m_transform = GetComponent<Transform>();
        SetRotation();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player" && collider.gameObject.tag != "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        FireInDirection();
        Destroy(gameObject, 1f);
    }
    public void setDirection(int dir)
    {
        direction = (Direction)dir;
    }

    void FireInDirection()
    {
        if (direction == Direction.NORTH)
        {
            m_transform.Translate(new Vector3(0, 0.35f), Space.World);
        }
        else if (direction == Direction.SOUTH)
        {
            m_transform.Translate(new Vector3(0, -0.35f), Space.World);
        }
        else if (direction == Direction.EAST)
        {
            m_transform.Translate(new Vector3(0.35f, 0), Space.World);
        }
        else if (direction == Direction.WEST)
        {
            m_transform.Translate(new Vector3(-0.35f, 0), Space.World);
        }
        else if (direction == Direction.NORTHEAST)
        {
            m_transform.Translate(new Vector3(0.247f, 0.247f), Space.World);
        }
        else if (direction == Direction.NORTHWEST)
        {
            m_transform.Translate(new Vector3(-0.247f, 0.247f), Space.World);
        }
        else if (direction == Direction.SOUTHEAST)
        {
            m_transform.Translate(new Vector3(0.247f, -0.247f), Space.World);
        }
        else if (direction == Direction.SOUTHWEST)
        {
            m_transform.Translate(new Vector3(-0.247f, -0.247f), Space.World);
        }
    }

    void SetRotation()
    {
        if (direction == Direction.NORTH)
        {
            m_transform.Rotate(0,0,270);
        }
        else if (direction == Direction.SOUTH)
        {
            m_transform.Rotate(0, 0, 90);
        }
        else if (direction == Direction.EAST)
        {
            m_transform.Rotate(0, 0, 180);
        }
        else if (direction == Direction.WEST)
        {
            m_transform.Rotate(0, 0, 0);
        }
        else if (direction == Direction.NORTHEAST)
        {
            m_transform.Rotate(0, 0, 225);
        }
        else if (direction == Direction.NORTHWEST)
        {
            m_transform.Rotate(0, 0, 315);
        }
        else if (direction == Direction.SOUTHEAST)
        {
            m_transform.Rotate(0, 0, 135);
        }
        else if (direction == Direction.SOUTHWEST)
        {
            m_transform.Rotate(0, 0, 45);
        }
    }

}
