using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public float MovementSpeed;
    public float DestroyTime;
    public float Damage;

    private Vector3 mousePosition;
    private Vector3 velocity;
    private float counter;

	// Use this for initialization
	void Start () {

        counter = 0f;

        // Mouse position
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        // Rotate towards mouse
        Vector3 diff = mousePosition - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 45);
    }

    // Once per FixedDeltaTime
    void FixedUpdate () {

        // Move the sword forwards
        velocity = (transform.up + transform.right).normalized * MovementSpeed * Time.fixedDeltaTime;
        transform.position += velocity;

        // Destroy the sword after enough time

        counter += Time.fixedDeltaTime;

        if (counter >= DestroyTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
