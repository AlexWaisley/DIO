using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstructionsH : MonoBehaviour
{
    private List<GameObject> InstFrag { get; set; }

    private void Start()
    {
        var t = GetComponent<Transform>();
        InstFrag = new List<GameObject>();
        for (var i = 0; i < t.childCount; i++) 
            InstFrag.Add(t.GetChild(i).gameObject);
    }
    public void OpenByCount(int count)
    {
        Close();
        for (var i = 0; i < count; i++) 
            InstFrag[i].SetActive(true);
    }

    public void Close()
    {
        foreach (var g in InstFrag) 
            g.SetActive(false);
    }
}
