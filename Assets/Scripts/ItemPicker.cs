using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] public List<string> items;
    [SerializeField] private Text itemCounter;
    [SerializeField] private Text itemCounterOut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Item")) return;
        var item = other.gameObject.GetComponent<ItemObject>();
        items.Add(item.id);
        itemCounter.text = items.Count.ToString();
        itemCounterOut.text = items.Count.ToString()+"/6";
        PlayerPrefs.SetInt($"Frags{SceneManager.GetActiveScene().name}", items.Count);
        PlayerPrefs.Save();
        Destroy(other.gameObject);
    }

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt($"Frags{SceneManager.GetActiveScene().name}"));
    }
}
