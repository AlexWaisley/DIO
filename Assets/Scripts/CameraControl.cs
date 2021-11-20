using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    private const float OffsetSmoothing = 5;
    private readonly Vector3 _offset = new Vector3(0,0,-10);
    public Vector3 maxValue;
    public Vector3 minValue;


    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        var targetPosition = target.position + _offset;
        var bound = new Vector3(Mathf.Clamp(targetPosition.x,minValue.x,maxValue.x),Mathf.Clamp(targetPosition.y,minValue.y,maxValue.y),Mathf.Clamp(targetPosition.z,minValue.z,maxValue.z));
        var smoothedPosition = Vector3.Lerp(transform.position,bound,OffsetSmoothing*Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
