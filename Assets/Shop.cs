using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    List<InventoryItem> shopItemList;
    List<InventoryItem> playerItemList;
    [SerializeField] Button shopButton;
    [SerializeField] GameObject shopItems;
    [SerializeField] GameObject playerItems;
    [SerializeField] GameObject shopUI;

    [SerializeField] InventoryItem bottles;
    [SerializeField] InventoryItem seeds;
    List<Button> shopButtons = new List<Button>();
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

            Button item1 = Instantiate(shopButton, shopItems.transform);


            Text[] namePrice = item1.GetComponentsInChildren<Text>();
            namePrice[0].text = item.name;
            namePrice[1].text = item.price.ToString() + " G";
            shopButtons.Add(item1);

        }

    }
    private void Update()
    {
        if (shopUI.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            { 
            shopUI.SetActive(false);
        }
    }

    public void EnterShop()
    {
        shopUI.SetActive(true);
        playerItemList.Clear();
        foreach (Transform child in playerItems.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (InventoryItem item in Inventory.instance.items )
        {
            if (item.amount > 0 && !shopItemList.Contains(item as InventoryItem))
            {
                playerItemList.Add(item);
            }

        }
        foreach(InventoryItem item in playerItemList)
        {
            Button item1 = Instantiate(shopButton, playerItems.transform);


            Text[] namePrice = item1.GetComponentsInChildren<Text>();
            namePrice[0].text = item.name;
            namePrice[1].text = item.price.ToString() + " G";
            shopButtons.Add(item1);
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
        Inventory.instance.Remove(item,1);
    }
}
