using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] UnityEvent onInteraction;

    public void Trigger()
    {
        onInteraction.Invoke();
    }
}
