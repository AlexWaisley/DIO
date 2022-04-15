using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] public GameObject playerPrefab;
    [SerializeField] public Transform spawnPosition;
    [SerializeField] public GameObject scene;
    [SerializeField] private float speed = 10;
    [SerializeField] private float jump = 13;
    private GroundChecker m_GroundDetector;
    public GameObject player;
    private Rigidbody2D m_Rb;
    private Animator m_Animator;

    public bool IsFrozen
    {
        set => m_Rb.constraints = value ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.FreezeRotation;
    }

    private float m_MoveX;

    private void Update()
    {
        m_Rb.velocity = new Vector2(m_MoveX, m_Rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        m_MoveX = ctx.ReadValue<Vector2>().x * speed;


        m_Animator.Play(Mathf.Abs(m_MoveX) > 0.2 ? "Rogue_run_01" : "Rogue_idle_01");
        if (m_MoveX > 0.2)
            m_Rb.transform.localScale = new Vector3(1, 1, 1);
        else if (m_MoveX < -0.2)
            m_Rb.transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!m_GroundDetector.OnGround) return;
        m_Rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        m_GroundDetector.OnGround = false;
    }

    public void Spawn()
    {
        player = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
        player.transform.parent = scene.transform;
        m_Rb = player.GetComponent<Rigidbody2D>();
        m_GroundDetector = player.GetComponentInChildren<GroundChecker>();
        m_Animator = player.GetComponentInChildren<Animator>();
    }
}