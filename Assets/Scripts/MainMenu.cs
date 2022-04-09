using System;
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
    [SerializeField] private List<UnityEngine.UI.Image> levelButtons;
    [SerializeField] private Color c1;
    [SerializeField] private Color c2;
    [SerializeField] private Color c3;

    public void LoadLevel(int level) => SceneManager.LoadScene($"Lvl_{level}");
    public void ResetData()
    {
        MemoryManager.ResetData();
        UpdateColors();
    }

    private void UpdateColors()
    {
        var acLst = MemoryManager.GetValues();
        for (var i = 1; i <= MemoryManager.LevelCount; i++)
        {
            if (acLst[i] < 2)
                levelButtons[i-1].color = c1;
            else if (acLst[i] < 5)
                levelButtons[i-1].color = c2;
            else if (acLst[i] >= 5) levelButtons[i-1].color = c3;
        }
    }
    
    public void Start() => UpdateColors();

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
    public void Exit() => Application.Quit();
}