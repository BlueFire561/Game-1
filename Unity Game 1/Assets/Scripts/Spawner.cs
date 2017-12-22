﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int SpawnSpeed;
    public GameObject EnemyPrefab;
    private float timerCounter;

    // Use this for initialization
    void Start () {
        timerCounter = 0f;
	}
	
	// Update is called once per fixeddeltatime
	void FixedUpdate () {

        timerCounter += Time.fixedDeltaTime;

        if (timerCounter >= SpawnSpeed)
        {
            timerCounter -= SpawnSpeed;
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        }

	}
}