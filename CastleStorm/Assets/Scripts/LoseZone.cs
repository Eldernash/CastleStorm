﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour {

    public GameController controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            controller.life--;
            controller.enemiesRemaining--;
            Destroy(other.gameObject);
        }
    }
}
