using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rigidbody2D;

    public float MovementSpeed;

    public GameObject SwordPrefab;
    public float AttackCooldown;
    private float counter;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        counter = 0f;
	}
	
	// Once per FixedDeltaTime
	void FixedUpdate () {

        // Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(x, y) * MovementSpeed * Time.fixedDeltaTime;

        rigidbody2D.MovePosition(rigidbody2D.position + velocity);


        // Attack
        if (counter < AttackCooldown)
        {
            counter += Time.fixedDeltaTime;
        }

        if (Input.GetMouseButton(0) && counter >= AttackCooldown)
        {
            counter = 0f;

            // Cooldown over
            Instantiate(SwordPrefab, transform.position, Quaternion.identity);
        }
    }
}
