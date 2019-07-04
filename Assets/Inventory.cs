using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryItem> items = new List<InventoryItem>();
  public  InventoryItem seeds;
   public InventoryItem bottles;

   public int money=0;
 public InventoryItem potions;
    public InventoryItem flowers;

    private void Start()
    {
        instance = this;
        seeds.price = 5;
        seeds.amount = 5;
        seeds.name = "Seeds";
        Add(seeds);
        bottles.price = 15;
        bottles.amount = 3;
        bottles.name = "Bottles";
        Add(bottles);

    }
    private void Update()
    {
        ShowUIThings.instance.seeds.text = "Seeds: " + seeds.amount;
        ShowUIThings.instance.bottles.text = "Bottles: " + bottles.amount;
        ShowUIThings.instance.money.text = "Gold: " + money;

    }

    public void Add(InventoryItem item)
    {
        item.gameObject.SetActive(false);
        if (!items.Contains(item))
        { 
        items.Add(item);
        
        }
        item.amount += 1;
    }
    public void Remove(InventoryItem item)
    {
        item.amount -= 1;
        if (item.amount == 0)
            items.Remove(item);
    }
}
