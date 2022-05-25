using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatleManager : MonoBehaviour
{
    [SerializeField] public BatleTimer timer;
    [SerializeField] public SlideManager sManager;
    [SerializeField] public int secsToRemoveInc;
    [SerializeField] public GameObject killScreen;

    private void Start()
    {
        sManager.incorrectClicked.AddListener(() => timer.RemoveSecs(secsToRemoveInc));
        sManager.onDone.AddListener(() =>
        {
            timer.gameObject.SetActive(false);
        });
        timer.timeEnds.AddListener(BadEnd);
        killScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        Debug.Log("exit");
        SceneManager.LoadScene("Menu");
    }

    private void BadEnd()
    {
        killScreen.SetActive(true);
        sManager.HideAll();
    }
}