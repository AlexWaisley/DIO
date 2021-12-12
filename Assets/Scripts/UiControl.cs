using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class UiControl : MonoBehaviour
{
    [SerializeField] private GameObject exitLog;

    [SerializeField] private Movement movement;
    
    public void ShowExitPanel()
    {
        exitLog.SetActive(true);
        movement.freeze = true;
    }
    public void HideExitPanel()
    {
        exitLog.SetActive(false);
        movement.freeze = false;
    }
   
    
}
