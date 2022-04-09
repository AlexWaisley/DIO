using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private UiControl uiControl;
    [SerializeField] private GameObject player;
    [SerializeField] private CameraControl cameraControl;
    [SerializeField] private LevelExit levelExit;
    private ItemPicker m_ItemPicker;
    private Movement m_PlayerMovement;

    private void Start()
    {
        m_PlayerMovement = player.GetComponent<Movement>();
        cameraControl.target = player;
        m_ItemPicker = player.GetComponentInChildren<ItemPicker>();
        m_ItemPicker.countChanged.AddListener(e =>
        {
            MemoryManager.UpdateFragmentsCount(levelNumber, e.Count);
            uiControl.FragCount = e.Count;
        });
        levelExit.onExit.AddListener(() => uiControl.pauseChanged.Invoke(true));
        uiControl.pauseChanged.AddListener(e => m_PlayerMovement.freeze = e);
    }
}
