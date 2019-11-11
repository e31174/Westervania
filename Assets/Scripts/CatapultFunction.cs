using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultFunction : MonoBehaviour {

    private Rigidbody2D m_Rigidbody2D;
    private void Awake()
    {
        // Setting up references.
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(wait());
            
            
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        m_Rigidbody2D.AddForce(new Vector2(0f, 3000f));
    }
}
