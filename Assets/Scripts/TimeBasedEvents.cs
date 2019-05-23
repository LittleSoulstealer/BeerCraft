using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeBasedEvents : MonoBehaviour, IObserver
{
    int day;
   [SerializeField] Sprite stage1;
   [SerializeField] Sprite stage2;
   SpriteRenderer sprRend;
   TimeKeep timeKeep;
   
    // Start is called before the first frame update
    void Start()
    {
        day = 0;
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

    void DayChange()
    {
        day++;
    }

    void Growing()
    {
        if (day==3)
        {
            sprRend.sprite = stage1;
            return;
        }
        if (day==5)
        {
            sprRend.sprite = stage2;
        }
    }

    public void UpdateFromSubject()
    {
        DayChange();
        Growing();
    }
}
