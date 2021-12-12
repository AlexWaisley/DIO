using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private GroundChecker groundDetector;
    private float _jTime = 0;
    public bool freeze;
    private void Update()
    {
        if (transform.position.y < -27)
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (!freeze)
        {
            var x = Input.GetAxis("Horizontal");
            Move(x);
            var jumpRq = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space));
            if (jumpRq && groundDetector.OnGround)
            {
                Jump();
            }
            if (groundDetector.MoveBlockOn != null)
            {
                transform.position -= groundDetector.MoveBlockOn.deltaFrame;
            }
        }
        else
        {
            Move(0);
        }
    }
    

    private void Move(float xMove)
    {
        body.velocity = new Vector2(xMove * speed, body.velocity.y);
    }

    private void Jump()
    {
        if (_jTime + 0.01 > Time.time) return; 
        body.velocity += new Vector2(0, speed);
        _jTime = Time.time;

    }

}