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
    [SerializeField] private GameObject settt;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject lvel;
    [SerializeField] private GameObject alert;
    [SerializeField] private GameObject about;
    [SerializeField] private GameObject confirm;
    [SerializeField] private Movement movement;
    private float a = 0;
    
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
    public void GoToVirus()
    {
        SceneManager.LoadScene("Lvl_1_Virus");
        a++;
    }

    public void settings()
    {
        settt.SetActive(true);
        Menu.SetActive(false);
    }
    public void levels()
    {
        lvel.SetActive(true);
        Menu.SetActive(false);
    }
    public void levelsOut()
    {
        lvel.SetActive(false);
        Menu.SetActive(true);
    }
    public void settingsOut()
    {
        settt.SetActive(false);
        Menu.SetActive(true);
    }
    public void abouTT()
    {
        about.SetActive(true);
        Menu.SetActive(false);
    }

    public void aboutOut()
    {
        about.SetActive(false);
        Menu.SetActive(true);
    }
    public void ConfirmExit()
    {
        Menu.SetActive(false);
        confirm.SetActive(true);
    }
    public void ConfirmExitNo()
    {
        confirm.SetActive(false);
        Menu.SetActive(true);
    }
    public void DropAll()
    {
        Application.Quit();
    }
    public void StartLvl1()
    {
        SceneManager.LoadScene("Lvl_1");
    }
    public void StartLvl2()
    {
        if (a > 0)
        {
            SceneManager.LoadScene("Lvl_2");
        }
        else
        {
            alert.SetActive(true);
            
        }
        
    }
    IEnumerator awwait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    
}
