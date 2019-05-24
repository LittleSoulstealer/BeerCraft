using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] List<ItemUI> itemSlots;

    void Start()
    {
        instance = this;
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ToggleInventoryVisibility();
    }

    private void ToggleInventoryVisibility()
    {
        if (inventoryPanel.activeInHierarchy)
            HidePanel();
        else
            ShowPanel();
    }

    private void ShowPanel()
    {
        inventoryPanel.SetActive(true);
        for(int i=0; i<inventory.items.Count; ++i)
        {
            itemSlots[i].SetLabel(inventory.items[i].name);
        }
    }

    private void HidePanel()
    {
        inventoryPanel.SetActive(false);

    }
}
