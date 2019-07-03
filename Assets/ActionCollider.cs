using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActionCollider : MonoBehaviour
{ 
    BoxCollider2D collider;
    GroundTile tile;
    Tilemap PlantTileMap;
   public bool isTriggered;



    public void WaterGround()
    {
  
       if(PlantTileMap!=null && PlantTileMap.gameObject.name== "PlantGround")
       {
           
            tile = (GroundTile)PlantTileMap.GetTile(Vector3Int.FloorToInt(transform.position));
            Debug.Log(tile.name);
            tile.WetGround();
            PlantTileMap.RefreshAllTiles();
  
       }



    }

    void Awake()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Debug.Log(collision+" Enter.");
        if(collision.gameObject.name == "PlantGround")
        {
            PlantTileMap = collision.gameObject.GetComponent<Tilemap>();
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision +" Exit.");
        if (collision.gameObject.name == "PlantGround")
        {
            PlantTileMap = null;
            isTriggered = false;
        }
    }

}
