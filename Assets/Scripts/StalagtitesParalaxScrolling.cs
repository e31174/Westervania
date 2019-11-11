using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagtitesParalaxScrolling : MonoBehaviour {

    [SerializeField]
    GameObject Camera;
    [SerializeField]
    GameObject Player;
    private Vector3 startingPosition;
    private Vector3 cameraStartingPosition;
    private GameObject This;
    private SpriteRenderer SR;
    private Color def;
    private Color cur;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        cameraStartingPosition = Camera.transform.position;
        This = this.gameObject;
        SR = This.GetComponent<SpriteRenderer>();
        SR.color = new Color(255, 255, 255, 0);
        def = SR.color;
        cur = SR.color;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3((cameraStartingPosition.x - Camera.transform.position.x) * -0.5f + startingPosition.x,
            (cameraStartingPosition.y - Camera.transform.position.y) * -0.7f + startingPosition.y,
            transform.position.z);

        if (Player.transform.position.y >= 12)
        {
            SR.color = def;
        }
        else if (Player.transform.position.y < 12 && Player.transform.position.y >= 7)
        {
            float ph = 12 - Player.transform.position.y;
            ph /= 5;
            SR.color = new Color(255, 255, 255, ph);
        } if (Player.transform.position.y < 7)
        {
            SR.color = new Color(255, 255, 255, 255);
        }
    }
}
