using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private Transform firstPos;
    [SerializeField] private Transform secondPos;
    [SerializeField] private GameObject square;
    [SerializeField] private float speed;
    [SerializeField] public Vector3 deltaFrame;

    private void Update()
    {
        var f1 = firstPos.transform.position;
        var f2 = secondPos.transform.position;
        var t = Mathf.Sin(Time.time * speed) / 2 + 0.5f;
        var dxf = Vector3.Lerp(f1, f2, t);
        deltaFrame = square.transform.position - dxf;
        square.transform.position = dxf;
    }
}