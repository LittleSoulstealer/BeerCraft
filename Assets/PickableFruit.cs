using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableFruit : InventoryItem
{
    
    public Plant myPlant;
    public override void AddMyselfToInventory()
    {
        this.transform.parent = Inventory.instance.transform;
        if (myPlant.isActiveAndEnabled)
        {
            myPlant.FreeSpace();
            myPlant.gameObject.SetActive(false); 
        }
        
        myPlant = null;

           
        
        base.AddMyselfToInventory();

    }

}
