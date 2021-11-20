using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private GroundChecker groundDetector;

    private void Update()
    {
        Debug.Log(groundDetector.OnGround);
        var x = Input.GetAxis("Horizontal");
        Move(x);
        var jumpRq = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space));
        if (jumpRq && groundDetector.OnGround)
        {
            Jump();
        }
        
    }

    private void Move(float xMove)
    {
        body.velocity = new Vector2(xMove * speed, body.velocity.y);
    }

    private void Jump()
    {
        body.velocity += new Vector2(0, speed);
        groundDetector.OnGround = false;
    }
    
}