using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    private void Start()
    {
        var uiControl = FindObjectOfType<UiControl>();
        var cameraControl = FindObjectOfType<CameraControl>();
        var levelExit = FindObjectOfType<LevelExit>();
        var playerControl = FindObjectOfType<PlayerControl>();
        
        playerControl.Spawn();
        
        cameraControl.target =  playerControl.player;
        
        var itemPicker = playerControl.player.GetComponentInChildren<ItemPicker>();
        itemPicker.countChanged.AddListener(e =>
        {
            MemoryManager.UpdateFragmentsCount(levelNumber, e.Count);
            uiControl.FragCount = e.Count;
        });
        
        levelExit.onExit.AddListener(() => uiControl.pauseChanged.Invoke(true));
        uiControl.pauseChanged.AddListener(e => playerControl.IsFrozen = e);
    }
}