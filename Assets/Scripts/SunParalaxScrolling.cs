using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunParalaxScrolling : MonoBehaviour {

    [SerializeField]
    GameObject Camera;
    private Vector3 startingPosition;
    private Vector3 cameraStartingPosition;


    // Use this for initialization
    void Start()
    {
        startingPosition = transform.position;
        cameraStartingPosition = Camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((cameraStartingPosition.x - Camera.transform.position.x) * -0.99f + startingPosition.x,
            (cameraStartingPosition.y - Camera.transform.position.y) * -0.99f + startingPosition.y,
            transform.position.z);
    }
}
