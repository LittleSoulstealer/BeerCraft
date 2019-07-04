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
    private void Start()
    {
        var timeKeepGO = GameObject.Find("TimeKeeper");
        if (timeKeepGO != null)
        {
            timeKeep = timeKeepGO.GetComponent<TimeKeep>();
        }
    }
    public void Brew()
    {
        if(Inventory.instance.flowers.amount>0 && Inventory.instance.bottles.amount>0 && !isBrewing)
            {
            isBrewing = true;
            Inventory.instance.flowers.amount += -5;
            Inventory.instance.bottles.amount += -1;
            timeKeep.RegisterObserver(this);
        }
    }

    public void UpdateFromSubject()
    {
        brewingDay++;
        if (brewingDay == 3)
        {
            CreatePotion(redPotion);
            finishedBrewing = true;
        }
    }

  void CreatePotion(RedPotion redPotion)
    {
        Vector3 potionPosision = transform.position;
        potionPosision.y += 3;
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
            timeKeep.RemoveObserver(this);
            brewingDay = 0;
            myPotion.AddMyselfToInventory();

            finishedBrewing = false;
        }
        
    }
}
