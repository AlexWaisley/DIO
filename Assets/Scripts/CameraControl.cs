using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float offsetSmoothing;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 maxValue;
    [SerializeField] private Vector3 minValue;
    private float zoomFactor = 3f;
    private float targetzoom;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        targetzoom = cam.orthographicSize;
    }

    private void FixedUpdate()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");
        targetzoom -= scrollData * zoomFactor;
        targetzoom = Mathf.Clamp(targetzoom, 4.5f, 15f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetzoom, Time.deltaTime);
        Follow();
    }

    private void Follow()
    {
        var targetPosition = target.position + offset;
        var clampedX = Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x);
        var clampedY =  Mathf.Clamp(targetPosition.y,minValue.y,maxValue.y);
        var bound = new Vector3(clampedX, clampedY, -10);
        transform.position =  Vector3.Lerp(transform.position,bound,offsetSmoothing*Time.deltaTime);
    }
}
