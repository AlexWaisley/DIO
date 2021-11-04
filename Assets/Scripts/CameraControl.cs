using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    private const float OffsetSmoothing = 3;
    private readonly Vector3 _offset = new Vector3(0,0,-10);


    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        var targetPosition = target.position + _offset;
        var smoothedPosition = Vector3.Lerp(transform.position,targetPosition,OffsetSmoothing*Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
