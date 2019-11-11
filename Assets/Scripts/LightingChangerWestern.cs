using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingChangerWestern : MonoBehaviour {

    [SerializeField] GameObject Player;
    private Light thisLight;
    private float defaultIntensity;

    // Use this for initialization
    void Start () {
        thisLight = GetComponent<Light>();
        defaultIntensity = thisLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.x >= 126)
        {
            float difference = (194 - Player.transform.position.x);
            if (difference != 0) {
                thisLight.intensity = difference / 100;
            }

        }
	}
}
