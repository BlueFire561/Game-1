using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public bool Active;

    public float SpawnSpeed;
    public GameObject EnemyPrefab;
    private GameObject enemy;
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

            if (Active)
            {
                enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = GameObject.Find("Enemies").transform; 
            }
        }

	}
}
