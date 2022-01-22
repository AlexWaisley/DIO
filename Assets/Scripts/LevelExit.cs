using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private UnityEvent onExit;
    [SerializeField] private GameObject exitLogS;
    [SerializeField] private Movement movement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(onExit);
        onExit.Invoke();
        Debug.Log(other.gameObject.tag);
    }
    public void HideExitPanelS()
    {
        exitLogS.SetActive(false);
        movement.freeze = false;
    }
    public void ProfitS()
    {
        SceneManager.LoadScene("Menu");
    }
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.P)) return;
        Debug.Log(exitLogS);
        Debug.Log(exitLogS.gameObject);
        exitLogS.SetActive(true);
        movement.freeze = true;
    }
}