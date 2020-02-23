using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActionCollider : MonoBehaviour
{ 

   public GameObject collidingGO;

   

    void Awake()
    {
       
  
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 

        if(collision.gameObject.name == "PlantGround")
        {
        }
        collidingGO = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlantGround")
        {
        }
    }

}
