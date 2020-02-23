using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    public HitPoints hitPoints;
    [HideInInspector] public PlayerController character;
    public Image meter;
    float maxHitPoints;
    // Start is called before the first frame update
    void Start()
    {
        maxHitPoints = character.maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            meter.fillAmount = hitPoints.value / maxHitPoints;

        }
        else
        {
            meter.fillAmount = 0f;
        }
    }
}
