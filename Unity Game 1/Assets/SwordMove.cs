using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour {
    public float speed; //Speed of sword
    public float delay; //How long sword
    public Vector3 targetPos; //Position of target
    public Vector3 mouse_pos ; //Position of mouse
    public Transform target ; //Assign to the object you want to rotate
    public Vector3 object_pos ; //Position of object
    public float angle; //Angle of sword
    public Transform Player; //Player Object

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
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 45;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
