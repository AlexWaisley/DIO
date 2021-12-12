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
   
    
    public void OpenMenu(GameObject panel)
    {
        movementPanel.SetActive(false);
        mainPanel.SetActive(false);
        levelPanel.SetActive(false);
        attentionPanel.SetActive(false);
        aboutPanel.SetActive(false);
        confirmExitPanel.SetActive(false);
        panel.SetActive(true);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    

}
