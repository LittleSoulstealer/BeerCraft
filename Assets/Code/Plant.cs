using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour, IObserver
{
    int dayOfMyLife=0;
    [SerializeField] Sprite stage0;
    [SerializeField] Sprite stage1;
    [SerializeField] Sprite stage2;
    [SerializeField] Sprite stage3;
    SpriteRenderer sprRend;
    TimeKeep timeKeep;
    public int daysBeforeStage1, daysBeforeStage2, daysBeforeStage3;
    GroundTile myGround;
    public PickableFruit myFruit;
    PickableFruit defaultFruit;

    public GroundTile MyGround { get => myGround; set => myGround = value; }

    public void UpdateFromSubject()
    {
        if (MyGround.isWet)
        {
            DayChange();

            Grow(daysBeforeStage1, daysBeforeStage2, daysBeforeStage3);
        }
    }

    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        defaultFruit = myFruit;
    
        var timeKeepGO = GameObject.Find("TimeKeeper");
        if (timeKeepGO != null)
        {
            timeKeep = timeKeepGO.GetComponent<TimeKeep>();
            timeKeep.RegisterObserver(this);
        }
    }
    public void newPlant()
    {
        dayOfMyLife = 0;
        
        sprRend.sprite = stage0;
        myFruit = defaultFruit;
       
    }
    public void FreeSpace()
    {
        MyGround.isFree = true;
        myFruit = null;
     
    }
    public virtual void DayChange()
    {
        dayOfMyLife++;
    }
    public virtual void Grow(int st1, int st2, int st3)
    {
        if(dayOfMyLife==st1)
        {
            sprRend.sprite = stage1;
            return;
        }
        if(dayOfMyLife == st2)
        {
            sprRend.sprite = stage2;
            return;
        }

        if(dayOfMyLife==st3)
        {
            sprRend.sprite = stage3;
            myFruit= Instantiate<PickableFruit>(myFruit, transform.position, Quaternion.identity, this.transform);
            myFruit.myPlant=this;
            return;
        }
    }

}
