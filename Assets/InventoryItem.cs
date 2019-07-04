using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string name;

    public virtual void AddMyselfToInventory()
    {
        Inventory.instance.Add(this);
        
    }
}