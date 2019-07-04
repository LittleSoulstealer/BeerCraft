using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TimeKeep : MonoBehaviour, ISubject
{

    int day=1;
    List<IObserver> timeDependant;
    public float secondsInFullDay = 5f;
    public float currentTimeOfDay = 0;
    public float timeMultiplier = 1f;


    public TimeKeep()
    {
        timeDependant  = new List<IObserver>(); 
    }


    private void Update()
    {
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        if (currentTimeOfDay >= 1)
        {
            ChangeDate();
            currentTimeOfDay = 0;
        }
    }

    public void ChangeDate()
    {
        day++;
        ShowUIThings.instance.dayCount.text = "Day: " + day;
         foreach (IObserver observer in timeDependant)
        {
            NotifyObserver(observer);
        }
        
    }


    public void RegisterObserver(IObserver o)
    {
        timeDependant.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        timeDependant.Remove(o);
    }

    public void NotifyObserver(IObserver o)
    {
        o.UpdateFromSubject();
    }
}
