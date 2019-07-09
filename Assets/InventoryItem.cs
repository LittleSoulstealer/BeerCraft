using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string name;
    [SerializeField] Sprite sprite;
    public int price;
    public int amount=0;

   
    public virtual void AddMyselfToInventory()
    {
        Inventory.instance.Add(this);
        
    }
}