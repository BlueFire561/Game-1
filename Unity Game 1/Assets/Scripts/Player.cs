using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rigidbody2D;

    public float HP;

    public bool ForceInvulnerability;
    private bool invulnerable;
    public float IVFrameDuration;
    private float ivFrameDurationCounter;

    public float MovementSpeed;


    public GameObject SwordPrefab;

    public float AttackCooldown;
    private float cooldownCounter;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        cooldownCounter = 0f;
        ivFrameDurationCounter = 0f;
        invulnerable = false;
	}
	
	// Once per FixedDeltaTime
	void FixedUpdate () {

        // Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(x, y) * MovementSpeed * Time.fixedDeltaTime;

        rigidbody2D.MovePosition(rigidbody2D.position + velocity);


        // Attack
        if (cooldownCounter < AttackCooldown)
        {
            cooldownCounter += Time.fixedDeltaTime;
        }

        if (Input.GetMouseButton(0) && cooldownCounter >= AttackCooldown)
        {
            cooldownCounter = 0f;

            // Cooldown over
            Instantiate(SwordPrefab, transform.position, Quaternion.identity, GameObject.Find("Bullets").transform);
        }


        // Invulnerability Frames
        if (invulnerable && ivFrameDurationCounter < IVFrameDuration)
        {
            ivFrameDurationCounter += Time.fixedDeltaTime;
        }

        if (ivFrameDurationCounter >= IVFrameDuration)
        {
            invulnerable = false;
            ivFrameDurationCounter = 0f;
        }


        // Health Bar
        this.gameObject.GetComponent<HealthBar>().Value = HP;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Enemy Collisions
        if (collision.gameObject.tag == "Enemy")
        {
            if (!invulnerable)
            {
                HP -= collision.gameObject.GetComponent<Enemy>().Damage;
                invulnerable = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bullet Collisions
        if (collision.gameObject.tag == "Bullet")
        {
            if (!invulnerable)
            {
                HP -= collision.gameObject.GetComponent<Bullet>().Damage;
                invulnerable = true;
            }
        }
    }

}
