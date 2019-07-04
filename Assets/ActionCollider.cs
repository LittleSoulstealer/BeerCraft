using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActionCollider : MonoBehaviour
{ 
    BoxCollider2D collider;
    GroundTile tile;
    Tilemap PlantTileMap;
   public bool pointingOnPlantGround;
    
    GameObject mySeeds;
   public GameObject collidingGO;



    public void WaterGround()
    {

        if (PlantTileMap != null && PlantTileMap.gameObject.name == "PlantGround")
        {

            tile = (GroundTile)PlantTileMap.GetTile(Vector3Int.FloorToInt(transform.position));
            Debug.Log(tile.name);
            tile.WetGround();
            PlantTileMap.RefreshAllTiles();
            tile = null;
        }

    }

    public bool Sow(Plant seeds)
    {
        tile = (GroundTile)PlantTileMap.GetTile(Vector3Int.FloorToInt(transform.position));
        
        if (tile.isFree)
        {
            tile.Sow(seeds);
            return true;
        }
        return false;
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
            pointingOnPlantGround = true;
        }
        collidingGO = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision +" Exit.");
        if (collision.gameObject.name == "PlantGround")
        {
            PlantTileMap = null;
            pointingOnPlantGround = false;
        }
    }

}
