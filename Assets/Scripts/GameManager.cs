using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private UiControl uiControl;
    [SerializeField] private CameraControl cameraControl;
    [SerializeField] private LevelExit levelExit;
    [SerializeField] private PlayerControl playerControl;
    private ItemPicker m_ItemPicker;

    private void Start()
    {
       
        
        playerControl.Spawn();
        cameraControl.target =  playerControl.player;
        m_ItemPicker = playerControl.player.GetComponentInChildren<ItemPicker>();
        m_ItemPicker.countChanged.AddListener(e =>
        {
            MemoryManager.UpdateFragmentsCount(levelNumber, e.Count);
            uiControl.FragCount = e.Count;
        });
        levelExit.onExit.AddListener(() => uiControl.pauseChanged.Invoke(true));
        uiControl.pauseChanged.AddListener(e => playerControl.IsFrozen = e);
    }
}