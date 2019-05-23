using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour, IObserver
{
    int day=0;
    [SerializeField] Sprite stage1;
    [SerializeField] Sprite stage2;
    [SerializeField] Sprite stage3;
    SpriteRenderer sprRend;
    TimeKeep timeKeep;
    public int st1, st2, st3;

       

    public void UpdateFromSubject()
    {
        DayChange();
        Grow(st1,st2,st3);
    }

    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        var timeKeepGO = GameObject.Find("TimeKeeper");
        if (timeKeepGO != null)
        {
            timeKeep = timeKeepGO.GetComponent<TimeKeep>();
            timeKeep.RegisterObserver(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void DayChange()
    {
        day++;
    }
    public virtual void Grow(int st1, int st2, int st3)
    {
        if(day==st1)
        {
            sprRend.sprite = stage1;
            return;
        }
        if(day == st2)
        {
            sprRend.sprite = stage2;
            return;
        }

        if(day==st3)
        {
            sprRend.sprite = stage3;
            return;
        }
    }

}
