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

    public int FragsCount()
    {
        var s = 0;
        s+=PlayerPrefs.GetInt($"FragsLvl_1");
        s+=PlayerPrefs.GetInt($"FragsLvl_2");
        s+=PlayerPrefs.GetInt($"FragsLvl_3");
        s+=PlayerPrefs.GetInt($"FragsLvl_4");
        s+=PlayerPrefs.GetInt($"FragsLvl_5");
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
