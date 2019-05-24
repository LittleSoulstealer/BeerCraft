using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Text label;

    public void SetLabel(string txt)
    {
        label.text = txt;
    }
}
