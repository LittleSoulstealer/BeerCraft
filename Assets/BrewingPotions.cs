using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingPotions : MonoBehaviour, IObserver
{
    int brewingDay=0;
    TimeKeep timeKeep;
    bool isBrewing;
    bool finishedBrewing;
   [SerializeField] RedPotion redPotion;
    RedPotion myPotion;
    SpriteRenderer sprRend;
    [SerializeField] Sprite notBrewingSprite;
    [SerializeField] Sprite brewingSprite;
    private void Start()
    {
        var timeKeepGO = GameObject.Find("TimeKeeper");
        if (timeKeepGO != null)
        {
            timeKeep = timeKeepGO.GetComponent<TimeKeep>();
        }
        sprRend = GetComponent<SpriteRenderer>();
    }
    public void Brew()
    {
        if(Inventory.instance.flowers.amount>4 && Inventory.instance.bottles.amount>0 && !isBrewing)
            {
            isBrewing = true;
            Inventory.instance.flowers.amount += -5;
            Inventory.instance.bottles.amount += -1;
            timeKeep.RegisterObserver(this);
            sprRend.sprite = brewingSprite;
        }
    }

    public void UpdateFromSubject()
    {
        brewingDay++;
        if (brewingDay == 1)
        {
            CreatePotion(redPotion);
            finishedBrewing = true;
            sprRend.sprite = notBrewingSprite;
        }
    }

  void CreatePotion(RedPotion redPotion)
    {
        timeKeep.RemoveObserver(this);
        Vector3 potionPosision = transform.position;
        potionPosision.y += 1.5f;
        RedPotion potion;
        if (myPotion == null)
        { potion = Instantiate<RedPotion>(redPotion, potionPosision, Quaternion.identity, transform);
            myPotion = potion;
        }
        else
            myPotion.gameObject.SetActive(true);
      
        
        
    }
    public void EmptyCauldron()
    {
        if (finishedBrewing)
        {
            isBrewing = false;
           
            brewingDay = 0;
            myPotion.AddMyselfToInventory();
            

            finishedBrewing = false;
        }
        
    }
}
