using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private float speed = 10;
    private Rigidbody2D body;
    private bool grounded = true;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(x*speed,body.velocity.y);
        if ((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))&&grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x,speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
}
