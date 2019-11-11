using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonParalaxScrolling : MonoBehaviour {

    [SerializeField] GameObject Camera;
    private Vector3 startingPosition;
    private Vector3 cameraStartingPosition;
    public float parallaxFactor;


    // Use this for initialization
    void Start()
    {
        startingPosition = transform.position;
        cameraStartingPosition = Camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((cameraStartingPosition.x - Camera.transform.position.x) * parallaxFactor + startingPosition.x,
            (cameraStartingPosition.y - Camera.transform.position.y) * parallaxFactor + startingPosition.y,
            transform.position.z);
    }
}
