using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private List<string> items;
    [SerializeField] private Text itemCounter;

    private void OnTriggerEnter2D(Collider2D other)
    { 
        
        if(!other.gameObject.CompareTag("Item")) return;

        var item = other.gameObject.GetComponent<ItemObject>();
        items.Add(item.id);
        itemCounter.text = items.Count.ToString();
        Destroy(other.gameObject);

    }
}
