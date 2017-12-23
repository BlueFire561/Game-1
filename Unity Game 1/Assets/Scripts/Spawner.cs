using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public bool Active;

    public float HP;
    private bool invulnerable;
    public float IVFrameDuration;
    private float ivFrameDurationCounter;

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

        // Spawn Enemies
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


        // Invulnerability
        if (invulnerable && ivFrameDurationCounter < IVFrameDuration)
        {
            ivFrameDurationCounter += Time.fixedDeltaTime;
        }

        if (ivFrameDurationCounter >= IVFrameDuration)
        {
            invulnerable = false;
            ivFrameDurationCounter = 0f;
        }


        // Death Event
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }


        // Health Bar
        this.gameObject.GetComponent<HealthBar>().Value = HP;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bullet Collision
        if (collision.gameObject.tag == "Sword")
        {
            Destroy(collision.gameObject);
            if (!invulnerable)
            {
                HP -= collision.gameObject.GetComponent<Sword>().Damage;
                invulnerable = true;
            }
        }
    }
}
