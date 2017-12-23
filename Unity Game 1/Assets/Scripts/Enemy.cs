using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float StopDistance;

    public float HP;

    private bool invulnerable;
    public float IVFrameDuration;
    private float ivFrameDurationCounter;

    public GameObject BulletPrefab;
    public float Damage;
    public float MaxFireDistance;
    public int Speed;
    private GameObject Player;
    private Rigidbody2D rigidbody2D;

    private GameObject bullet;

    public float AttackCooldown;
    private float attackCooldownCounter;

	// Use this for initialization
	void Start () {
        rigidbody2D = this.GetComponent<Rigidbody2D>();

        Player = GameObject.FindWithTag("Player");
	}
	
	// FixedUpdate is called once per fixeddeltatime
	void FixedUpdate () {

        // Rotate Towards Player
        Vector3 diff = Player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);


        // Move Forwards
        Vector3 velocity = transform.up * Speed * Time.fixedDeltaTime;
        if (Vector3.Distance(velocity + transform.position, Player.transform.position) < StopDistance)
        {
            velocity *= 0;
        }

        rigidbody2D.MovePosition(transform.position + velocity);


        // Attack
        if (attackCooldownCounter < AttackCooldown)
        {
            attackCooldownCounter += Time.fixedDeltaTime;
        }

        if (Vector3.Distance(this.transform.position, Player.transform.position) < MaxFireDistance && attackCooldownCounter >= AttackCooldown)
        {
            bullet = Instantiate(BulletPrefab, transform.position, this.transform.rotation, GameObject.Find("Bullets").transform);
            attackCooldownCounter = 0f;
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


        // Death Event
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            Destroy(collision.gameObject);
            if (!invulnerable)
            {
                HP -= collision.GetComponent<Sword>().Damage;
                invulnerable = true;
            }
        }
    }

}
