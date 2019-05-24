using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string name;

    public void AddMyselfToInventory()
    {
        Inventory.instance.Add(this);
    }
}