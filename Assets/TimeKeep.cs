using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeep : MonoBehaviour
{
    int day=1;

    public void ChangeDate()
    {
        day++;
        Debug.Log("Day: " + day);
    }
}
