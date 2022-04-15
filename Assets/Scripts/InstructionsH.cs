using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstructionsH : MonoBehaviour
{

    
    public void OpenByCount(int count)
    {
        var t = GetComponent<Transform>();
        var instFrag = new List<GameObject>();
        for (var i = 0; i < t.childCount; i++) 
            instFrag.Add(t.GetChild(i).gameObject);
        Close();
        for (var i = 0; i < Mathf.Min(instFrag.Count, count); i++) 
            instFrag[i].SetActive(true);
    }

    public void Close()
    {
        var t = GetComponent<Transform>();
        var instFrag = new List<GameObject>();
        for (var i = 0; i < t.childCount; i++) 
            instFrag.Add(t.GetChild(i).gameObject);
        foreach (var g in instFrag) 
            g.SetActive(false);
    }
}
