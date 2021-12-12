using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject movementPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject attentionPanel;
    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject confirmExitPanel;
    
    
    public void LoadLevel(int level)
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Lvl_1");
                break;
            
        }
      
    }

    public void OpenSettings()
    {
        movementPanel.SetActive(true);
        mainPanel.SetActive(false);
    }
    public void OpenLevels()
    {
        levelPanel.SetActive(true);
        mainPanel.SetActive(false);
    }
    public void levelsOut()
    {
        levelPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void settingsOut()
    {
        movementPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void abouTT()
    {
        aboutPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void aboutOut()
    {
        aboutPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void ConfirmExit()
    {
        mainPanel.SetActive(false);
        confirmExitPanel.SetActive(true);
    }
    public void ConfirmExitNo()
    {
        confirmExitPanel.SetActive(false);
        mainPanel.SetActive(true);
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
        if (false)
        {
            SceneManager.LoadScene("Lvl_2");
        }
        else
        {
            attentionPanel.SetActive(true);
            
        }
        
    }
    IEnumerator awwait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
