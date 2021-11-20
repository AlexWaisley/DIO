using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private List<string> items;

    private void OnTriggerEnter2D(Collider2D other)
    { 
        Debug.Log(other);
        if(!other.gameObject.CompareTag("Item")) return;

        var item = other.gameObject.GetComponent<ItemObject>();
        items.Add(item.id);
        Destroy(other.gameObject);

    }
}
