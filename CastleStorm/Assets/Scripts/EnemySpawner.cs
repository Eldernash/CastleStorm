﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnTimer = 2;
    public int spawnAmount;
    public GameObject prefab;

    private float timeRemaining;
	// Use this for initialization
	void Start () {
        timeRemaining = spawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeRemaining <= 0 && spawnAmount > 0) {
            
            Instantiate(prefab);
            timeRemaining = spawnTimer;
            spawnAmount--;
        } else {
            timeRemaining -= 1 * Time.deltaTime;
        }
	}
}