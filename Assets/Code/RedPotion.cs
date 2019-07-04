using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : InventoryItem
{
  
    public override void AddMyselfToInventory()
    {
        Inventory.instance.potions.amount += 1;
        base.AddMyselfToInventory();
    }

}
