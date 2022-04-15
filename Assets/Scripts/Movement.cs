using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float jump = 13;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private GroundChecker groundDetector;
    [SerializeField] private Animator animator;
    private float m_JTime = 0;
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
            var jumpRq = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ||
                          Input.GetKeyDown(KeyCode.Space));
            if (jumpRq && groundDetector.OnGround) { Jump(); }
            if (groundDetector.MoveBlockOn != null)
            {
                transform.position -= groundDetector.MoveBlockOn.deltaFrame;
            }
        }
        else { Move(0); }
    }
    private void Move(float xMove)
    {
        body.velocity = new Vector2(xMove * speed, body.velocity.y);
        animator.Play(Mathf.Abs(xMove) > 0.2 ? "Rogue_run_01" : "Rogue_idle_01");
    }

    private void Jump()
    {
        if (m_JTime + 0.01 > Time.time) return;
        body.velocity += new Vector2(0, jump);
        m_JTime = Time.time;
    }
    private bool m_FacingLeft = true;
    private void LateUpdate()
    {
        var localScale = body.transform.localScale;
        if (body.velocity.x < -0.1)
            m_FacingLeft = false;
        else if (body.velocity.x > 0.1) m_FacingLeft = true;
        if (((m_FacingLeft) && (localScale.x < 0)) || ((!m_FacingLeft) && (localScale.x > 0))) localScale.x *= -1;
        body.transform.localScale = localScale;
    }
}