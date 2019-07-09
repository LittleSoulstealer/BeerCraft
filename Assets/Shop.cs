using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    List<InventoryItem> shopItemList;
    List<InventoryItem> playerItemList;
    [SerializeField] ShopItemButton shopButton;
    [SerializeField] GameObject shopItems;
    [SerializeField] GameObject playerItems;
    [SerializeField] GameObject shopUI;
    [SerializeField] GameObject player;

    [SerializeField] InventoryItem bottles;
    [SerializeField] InventoryItem seeds;

    Button currentButton;

    // Start is called before the first frame update


    void Start()
    {

        shopItemList = new List<InventoryItem>();

        playerItemList = new List<InventoryItem>();
        SetShop();
        shopUI.SetActive(false);

    }
    
    void SetShop()
    {
        bottles = Instantiate(bottles, transform);
        seeds = Instantiate(seeds, transform);
        shopItemList.Add(bottles);
        shopItemList.Add(seeds);
        foreach (InventoryItem item in shopItemList)
        {

            ShopItemButton item1 = Instantiate(shopButton, shopItems.transform);
            item1.item = item;
            item1.SetButton();
        }

    }
    private void Update()
    {
        if (shopUI.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            { 
            shopUI.SetActive(false);
            
            player.GetComponent<PlayerController>().enabled = true;
            Time.timeScale = 1;
        }
      
    }

    public void EnterShop()
    {
        shopUI.SetActive(true);

        player.GetComponent<PlayerController>().enabled = false;
        Time.timeScale = 0;
    

        playerItemList.Clear();
        foreach (Transform child in playerItems.transform)
        {
            GameObject.Destroy(child.gameObject);
        
        }
     

        foreach (InventoryItem item in Inventory.instance.items )
        {
            if ( (item.amount > 0) && !(shopItemList.Where(x => x.name == item.name).Count() > 0))
           
              
            {
                playerItemList.Add(item);
            }

        }
        foreach(InventoryItem item in playerItemList)
        {
            ShopItemButton item1 = Instantiate(shopButton, playerItems.transform);
            item1.item = item;
            item1.SetButton();

        }

        //currentButton = shopButtons[0];
       // currentButton.Select();
    }

   public void Buy(ShopItemButton itemButton)

    {
        bool buying = false;
        InventoryItem theItem = Inventory.instance.items.FirstOrDefault(x => x.name == itemButton.item.name);
        if (itemButton.transform.parent == shopItems.transform)
            buying = true;
       
        if (buying == true)
        {
            if (Inventory.instance.money >= theItem.price)
            {
                Inventory.instance.money -= theItem.price;
                Inventory.instance.Add(theItem);
            }
        }
        else { Sell(theItem); }
          
        
    }
   public void Sell(InventoryItem item)
    {
        if(item.amount>0)
        {
            Inventory.instance.money += item.price;
            Inventory.instance.Remove(item, 1);
        }
        
    }


}
