using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform feetPos;
    public float acceleration = 350f;
    public float maxSpeed = 5f;
    public float jumpAcceleration = 400f;
    
    private Rigidbody2D body;
    private bool onGround = false;
    private bool jumping = false;
    
    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        onGround = Physics2D.Linecast(transform.position, feetPos.position, 1<<LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && onGround)
        {
            jumping = true;
        }
    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");

        body.AddForce(Vector2.right * horiz * acceleration);

        if (Mathf.Abs(body.velocity.x) > maxSpeed)
        {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * maxSpeed, body.velocity.y);
        }

        if (jumping)
        {
            body.AddForce(Vector2.up * jumpAcceleration);
            jumping = false;
        }
    }
}
