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

    private IEnumerator AttentionShow()
    {
        attentionPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        attentionPanel.SetActive(false);
    }

    public void LoadLevel(int level)
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Lvl_1");
                break;
            case 2:
                if (PlayerPrefs.GetInt($"FragsLvl_1") < 2)
                {
                    StartCoroutine(AttentionShow());
                    break;
                }

                SceneManager.LoadScene("Lvl_2");
                break;
        }
    }

    public void Start()
    {
        var acLst = new List<int>()
        {
            PlayerPrefs.GetInt($"FragsLvl_1"),
            PlayerPrefs.GetInt($"FragsLvl_2"),
            PlayerPrefs.GetInt($"FragsLvl_3"),
            PlayerPrefs.GetInt($"FragsLvl_4"),
            PlayerPrefs.GetInt($"FragsLvl_5"),
        };
        for (var i = 0; i < 5; i++)
        {
            Debug.Log(acLst[i]);
            if (acLst[i] < 2)
            {
                levelButtons[i].color = c1;
            }
            else if (acLst[i] < 5)
            {
                levelButtons[i].color = c2;
            }
            else if (acLst[i] >= 5)
            {
                levelButtons[i].color = c3;
            }
        }
    }

    public int FragsCount()
    {
        var s = 0;
        s += PlayerPrefs.GetInt($"FragsLvl_1");
        s += PlayerPrefs.GetInt($"FragsLvl_2");
        s += PlayerPrefs.GetInt($"FragsLvl_3");
        s += PlayerPrefs.GetInt($"FragsLvl_4");
        s += PlayerPrefs.GetInt($"FragsLvl_5");
        return s;
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