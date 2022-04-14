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
    [SerializeField] private GameObject virusInstr;
    [SerializeField] private GameObject attentionPanel;
    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject instrPanel;
    [SerializeField] private GameObject confirmExitPanel;
    [SerializeField] private List<UnityEngine.UI.Image> levelButtons;
    [SerializeField] private List<UnityEngine.UI.Text> fragCountOnLvl;
    [SerializeField] private List<GameObject> info1;
    [SerializeField] private List<GameObject> instr1;
    [SerializeField] private List<GameObject> info2;
    [SerializeField] private List<GameObject> instr2;
    [SerializeField] private List<GameObject> info3;
    [SerializeField] private List<GameObject> instr3;
    [SerializeField] private Color c1;
    [SerializeField] private Color c2;
    [SerializeField] private Color c3;

    public void LoadLevel(int level) => SceneManager.LoadScene($"Lvl_{level}");

    public void ShowInstr_1()
    {
        var acLst = MemoryManager.GetValues();
        virusInstr.SetActive(true);
        for (var i = 0; i < acLst[1]; i++)
        {
            info1[i].SetActive(true);
        }
        for (var i = 0; i < acLst[2]; i++)
        {
            instr1[i].SetActive(true);
        }
    }
    public void ShowInstr_2()
    {
        var acLst = MemoryManager.GetValues();
        virusInstr.SetActive(true);
        for (var i = 0; i < acLst[3]; i++)
        {
            info2[i].SetActive(true);
        }
        for (var i = 0; i < acLst[4]; i++)
        {
            instr2[i].SetActive(true);
        }
    }
    public void ShowInstr_3()
    {
        var acLst = MemoryManager.GetValues();
        virusInstr.SetActive(true);
        for (var i = 0; i < acLst[5]; i++)
        {
            info3[i].SetActive(true);
        }
        for (var i = 0; i < acLst[6]; i++)
        {
            instr3[i].SetActive(true);
        }
    }
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
            fragCountOnLvl[i-1].text = $"{acLst[i]}/6";
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
        virusInstr.SetActive(false);
        aboutPanel.SetActive(false);
        confirmExitPanel.SetActive(false);
        instrPanel.SetActive(false);
        panel.SetActive(true);
    }
    public void Exit() => Application.Quit();
}