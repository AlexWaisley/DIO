using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    [SerializeField] public GameObject target;

    [SerializeField] private float offsetSmoothing;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 maxValue;
    [SerializeField] private Vector3 minValue;
    private const float ZoomFactor = 2f;
    private float m_TargetZoom;
    private Camera m_Cam;

    private void Start()
    {
        m_Cam = GetComponent<Camera>();
        m_TargetZoom = m_Cam.orthographicSize;
    }

    private void FixedUpdate() => Follow();

    public void Zoom(InputAction.CallbackContext ctx)
    {
        var amount = -Mathf.Clamp(ctx.ReadValue<float>(), -1f, 1f) * ZoomFactor;
        m_TargetZoom = Mathf.Clamp(m_TargetZoom + amount, 4.5f, 15f);
    }

    public void Update()
    {
        m_Cam.orthographicSize = Mathf.Lerp(m_Cam.orthographicSize, m_TargetZoom, Time.deltaTime * ZoomFactor);
    }

    private void Follow()
    {
        var targetPosition = target.transform.position + offset;
        var clampedX = Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x);
        var clampedY = Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y);
        var bound = new Vector3(clampedX, clampedY, -10);
        transform.position = Vector3.Lerp(transform.position, bound, offsetSmoothing * Time.deltaTime);
    }
}