using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallthroughCommand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //tracks if the button combo for falling through is pressed
        //usually in video games this is down + jump
        if (Input.GetAxis("Vertical") == -1)
        {
            //the layer moving platforms cannot collide with
            gameObject.layer = 8;
        }
        else
        {
            gameObject.layer = 0; //default layer
        }
   }

}
