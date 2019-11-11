using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoopsDirectionalLightingScript : MonoBehaviour {

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
        if (Player.transform.position.y >= 14)
        {
            thisLight.intensity = defaultIntensity;
        }
        else if (Player.transform.position.y < 14 && Player.transform.position.y >= 7)
        {
            float ph = 14 - Player.transform.position.y;
            ph /= 7;
            ph = 1 - ph;
            thisLight.intensity = ph;
        }
        if (Player.transform.position.y < 7)
        {
            thisLight.intensity = 0;
        }
    }
}
