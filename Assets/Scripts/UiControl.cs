using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiControl : MonoBehaviour
{
    [SerializeField] private GameObject exitLog;
    public UnityEvent<bool> pauseChanged;

    [SerializeField] private Text counterText;
    public int FragCount
    {
        set => counterText.text = value.ToString();
    }
    private void Start()
    {
        pauseChanged.AddListener(e => exitLog.SetActive(e));
        pauseChanged.Invoke(false);
        FragCount = 0;
    }

    public void HideExitPanel() => pauseChanged.Invoke(false);
    public void Exit() => SceneManager.LoadScene("Menu");
}