using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingLayerSetter : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public bool updateEveryFrame = false;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSortingOrder();
    }

    void Update()
    {
        if(updateEveryFrame)
            SetSortingOrder();
    }

    private void SetSortingOrder()
    {
        spriteRenderer.sortingOrder = GetSortingOrder();
    }

    private int GetSortingOrder()
    {
        return GetBaseHeightInCm();
    }

    private int GetBaseHeightInCm()
    {
        return -(int)transform.position.y*100;
    }
}
