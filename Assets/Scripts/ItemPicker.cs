using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private List<float> items;
    public UnityEvent<List<float>> countChanged;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Item")) return;
        items.Add(Time.time);
        countChanged.Invoke(items);
        Destroy(other.gameObject);
    }

}
