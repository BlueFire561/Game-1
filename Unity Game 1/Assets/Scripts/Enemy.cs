﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float Damage;
    public int Speed;
    private GameObject Player;
    private Rigidbody2D rigidbody2D;
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
        if ( Vector3.Distance(this.transform.position, Player.transform.position) > 2 )
        {
            rigidbody2D.MovePosition(transform.position + (transform.up * Speed * Time.fixedDeltaTime)); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            Destroy(this.gameObject);
        }
        Debug.Log(collision);
    }

}
