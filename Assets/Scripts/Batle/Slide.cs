скusing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{
    [SerializeField] private List<Button> incorrect; 
    [SerializeField] private List<Button> correct; 
    [SerializeField] public UnityEvent missAns; 
    [SerializeField] public UnityEvent rightAns; 
    
    void Start()
    {
        foreach (var b in incorrect) 
            b.onClick.AddListener(missAns.Invoke);
        foreach (var b in correct) 
            b.onClick.AddListener(rightAns.Invoke);
    }
    
}
