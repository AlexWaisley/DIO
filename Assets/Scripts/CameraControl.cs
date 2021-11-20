using UnityEngine;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float offsetSmoothing;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 maxValue;
    [SerializeField] private Vector3 minValue;
    private void FixedUpdate()
    {
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
