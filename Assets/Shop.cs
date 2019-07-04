using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{
    List<InventoryItem> shopItemList;
    int[] shopPrices;
    List<InventoryItem> playerItemList;
    int money;
    // Start is called before the first frame update

     
    void Start()
    {
       
        shopItemList = new List<InventoryItem>
        {
         
        };

    }

    void EnterShop()
    {
        playerItemList = new List<InventoryItem>();


        foreach (InventoryItem item in Inventory.instance.items)
        {
            if (item.amount > 0 && !shopItemList.Contains(item))
            {
                playerItemList.Add(item);
            }

        }
    }

    void Buy(InventoryItem item)
    {
        if (Inventory.instance.money > item.price)
        {
            Inventory.instance.money -= item.price;
            Inventory.instance.Add(item);
        }
    }
    void Sell(InventoryItem item)
    {
        Inventory.instance.money += item.price;
        Inventory.instance.items.Remove(item);
    }
}
