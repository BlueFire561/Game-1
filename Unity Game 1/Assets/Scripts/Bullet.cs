using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float MovementSpeed;
    public float Damage;
    public float DestroyTime;
    private float destroyTimeCounter;

	// Use this for initialization
	void Start () {
		
	}

    // Once per FixedDeltaTime
    void FixedUpdate () {
        transform.position += transform.up * MovementSpeed * Time.fixedDeltaTime;

        destroyTimeCounter += Time.fixedDeltaTime;
        if (destroyTimeCounter >= DestroyTime)
        {
            Destroy(this.gameObject);
        }
	}
}
