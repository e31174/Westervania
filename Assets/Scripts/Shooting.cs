using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Object bullet;
    private Rigidbody2D m_RigidBody;
    private Quaternion m_Quaternion;
    private GameObject[] bullets;
    public AudioClip gunShot;
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

    private int heldFire;
	// Use this for initialization
	void Start () {
        heldFire = 0;
        m_RigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("HorizontalQuick") == 1) direction = Direction.EAST;
        else if (Input.GetAxis("VerticalQuick") == 0 && Input.GetAxis("HorizontalQuick") == -1) direction = Direction.WEST;
        else if (Input.GetAxis("VerticalQuick") == 1 && Input.GetAxis("HorizontalQuick") == 0) direction = Direction.NORTH;
        else if (Input.GetAxis("VerticalQuick") == -1 && Input.GetAxis("HorizontalQuick") == 0) direction = Direction.SOUTH;
        else if (Input.GetAxis("VerticalQuick") == 1 && Input.GetAxis("HorizontalQuick") == 1) direction = Direction.NORTHEAST;
        else if (Input.GetAxis("VerticalQuick") == 1 && Input.GetAxis("HorizontalQuick") == -1) direction = Direction.NORTHWEST;
        else if (Input.GetAxis("VerticalQuick") == -1 && Input.GetAxis("HorizontalQuick") == 1) direction = Direction.SOUTHEAST;
        else if (Input.GetAxis("VerticalQuick") == -1 && Input.GetAxis("HorizontalQuick") == -1) direction = Direction.SOUTHWEST;

        if (Input.GetButton("Fire2"))
        {
           if (heldFire == 0 && bullets.Length < 3)
           {
                GetComponent<AudioSource>().PlayOneShot(gunShot);
                m_RigidBody = GetComponent<Rigidbody2D>();
                GameObject instBullet = Instantiate(bullet, new Vector3(m_RigidBody.position.x, m_RigidBody.position.y), Quaternion.identity) as GameObject;
                instBullet.GetComponent<BulletBehavior>().setDirection(direction.GetHashCode());
           }
           heldFire++;
        } else if (!Input.GetButton("Fire2"))
        {
            heldFire = 0;
        }
    }
}
