using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private float cooleddown;
    public Transform Sword;
    public Transform playerpos;
    public float cooldowntime;


	// Use this for initialization
	void Start () {
        cooleddown = 0.0f;
    }

   

        // Update is called once per frame
        void Update () {
        if(cooleddown > 0.0f)
        {
            cooleddown -= 1.0f;

        }

        if (Input.GetMouseButtonDown(0)){
            if(cooleddown == 0)
            {
                
                Instantiate(Sword, playerpos.position, Quaternion.identity);
                    cooleddown = cooldowntime;
            }
        }

    }
}
