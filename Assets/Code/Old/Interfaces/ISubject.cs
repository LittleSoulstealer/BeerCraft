using System.Collections;
using System.Collections.Generic;


public interface ISubject 
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObserver(IObserver o);

}
