using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public GameObject player;
    public Image healthStars;
    [SerializeField] public Sprite[] star = new Sprite[0];

	void Start () {
		
	}
	
	public void SetHealth(int playerHealth) {
        if (playerHealth < 0) playerHealth = 0;
        healthStars.sprite = star[playerHealth];
    }
}
