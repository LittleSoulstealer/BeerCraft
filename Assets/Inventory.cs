using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryItem> items = new List<InventoryItem>();
    public InventoryItem seeds;
    public InventoryItem bottles;

    public int money;
    public InventoryItem potions;
    public InventoryItem flowers;

    private void Start()
    {
        instance = this;
        money = 0;
    
        flowers =Instantiate(flowers, this.transform);
        items.Add(flowers);
       

        potions = Instantiate(potions, this.transform);
        potions.GetComponent<SpriteRenderer>().enabled = false;

        items.Add(potions);
        seeds = Instantiate(seeds, this.transform);
        bottles = Instantiate(bottles, this.transform);

        items.Add(seeds);
        items.Add(bottles);
        flowers.amount = 20;
 


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
        item.amount += 1;
    }
    public void Remove(InventoryItem item, int amount)
    {
        item.amount -= amount;


    }
}
