using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryItem> items = new List<InventoryItem>();

    private void Start()
    {
        instance = this;
    }

    public void Add(InventoryItem item)
    {
        item.gameObject.SetActive(false);
        items.Add(item);
    }
}
