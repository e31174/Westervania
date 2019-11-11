using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warptrigger1to2 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        SceneManager.LoadScene(2);
    }
}
