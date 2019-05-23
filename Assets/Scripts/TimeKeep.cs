using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TimeKeep : MonoBehaviour, ISubject
{

    int day=1;
    List<IObserver> timeDependant;

    public TimeKeep()
    {
        timeDependant  = new List<IObserver>(); 
    }

    private void Start()
    {
        
    }

    public void ChangeDate()
    {
        day++;
        Debug.Log("Day: " + day);
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
