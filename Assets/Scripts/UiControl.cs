
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiControl : MonoBehaviour
{
    [SerializeField] private GameObject exitLog;

    [SerializeField] private Movement movement;
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

    public void Profit()
    {
        SceneManager.LoadScene("Menu");
    }

}