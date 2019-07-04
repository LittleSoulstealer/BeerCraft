using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIThings : MonoBehaviour
{
   public Text dayCount;
    public Text seeds;
    public Text bottles;
    public Text money;
    TimeKeep timeKeep;

    public static ShowUIThings instance;
    private void Start()
    {
        instance = this;
    }

}
