using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public HitPoints hitPoints;
    public int healingAmount=1;
    [SerializeField]PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log(collision);
        if (hitPoints.value < player.maxHitPoints)
        {
            hitPoints.value += healingAmount;
            Destroy(gameObject);
        }
    }
           

        
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
