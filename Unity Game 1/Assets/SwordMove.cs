using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour {
    public float speed;
    public float delay;
    public Vector3 targetPos;
    public Vector3 mouse_pos ;
    public Transform target ; //Assign to the object you want to rotate
    public Vector3 object_pos ;
    public float angle;
    public Transform Player;

	// Use this for initialization
	void Start () {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartCoroutine(Delay());
        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update () {
      
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);



        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 45;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
