using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : Button

{
    public InventoryItem item;

    public void SetButton()
    {
        Text[] namePrice = GetComponentsInChildren<Text>();
        namePrice[0].text = item.name;
        namePrice[1].text = item.price.ToString() + " G";
    }
    
}
