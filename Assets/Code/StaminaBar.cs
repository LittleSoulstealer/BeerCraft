using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Stamina stamina;
    [HideInInspector] public PlayerController character;
    public Image meter;
    float maxStamina;
    // Start is called before the first frame update
    void Start()
    {
        maxStamina = character.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            meter.fillAmount = stamina.value / maxStamina;

        }
        else
        {
            meter.fillAmount = 0f;
        }
    }
}
