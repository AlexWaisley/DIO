using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private UnityEvent onExit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(onExit);
        onExit.Invoke();
        Debug.Log(other.gameObject.tag);
    }
    

}
