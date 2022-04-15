using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] public GameObject playerPrefab;
    [SerializeField] private float speed = 10;
    [SerializeField] private float jump = 13;
    [SerializeField] private AnimationCurve moveCur;
    private GroundChecker m_GroundDetector;
    public GameObject player;
    private Rigidbody2D m_Rb;
    private Animator m_Animator;
    private bool m_Frozen;

    public bool IsFrozen
    {
        set
        {
            m_Frozen = value;
            m_Rb.constraints = value ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private float m_MoveX;
    private const float AccelSpeed = 4f;
    private float m_TimeX;
    private float m_LastDirection;

    private void Update()
    {
        if (m_MoveX != 0)
        {
            m_LastDirection = m_MoveX;
            m_TimeX += Time.deltaTime * AccelSpeed;
        }
        else
            m_TimeX -= Time.deltaTime * AccelSpeed;

        m_TimeX = Mathf.Clamp(m_TimeX, 0, 1);
        var moveX = moveCur.Evaluate(m_TimeX) * m_LastDirection;
        m_Rb.velocity = new Vector2(moveX * speed, m_Rb.velocity.y);
        
        m_Animator.Play(Mathf.Abs(moveX) > 0.1 ? "Rogue_run_01" : "Rogue_idle_01");
        if (moveX > 0.1)
            m_Rb.transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < -0.1)
            m_Rb.transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        m_MoveX = ctx.ReadValue<Vector2>().x;
        if (m_Frozen) m_MoveX = 0;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!m_GroundDetector.OnGround) return;
        m_Rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        m_GroundDetector.OnGround = false;
    }

    public void Spawn()
    {
        var spawnPosition = GameObject.FindGameObjectWithTag("SpawnPosition").transform;
        player = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
        player.transform.parent = spawnPosition.parent;
        m_Rb = player.GetComponent<Rigidbody2D>();
        m_GroundDetector = player.GetComponentInChildren<GroundChecker>();
        m_Animator = player.GetComponentInChildren<Animator>();
    }
}