using UnityEngine;
using System.Collections;
public class MovementOfPlayer : MonoBehaviour {
    public Rigidbody2D rigidbody;
    public Vector2 velocity;
    public float speed;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate () {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;
        Vector2 velocity = new Vector2(x, y);
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);

    }
}
