﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnTimer = 2;
    public int spawnAmount;
    public GameObject prefab;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn() {
        Instantiate(prefab, transform);
    }
}