using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GroundTile : Tile
{
    public bool isWet;
    public bool isFree;

    public Sprite wetGround;
    public Sprite dryGround;
    public ITilemap tileMap;
    public Plant myPlant;
  

    Vector3 myCenter;

    public GroundTile()
    {
        isWet = false;
        isFree = true;
    }

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        this.tileMap = tilemap;
        
       
       
        myCenter = new Vector3(position.x+0.5f, position.y+0.5f, 0f);
   
        return base.StartUp(position, tilemap, go);
    }

   public void Sow(Plant seeds)
    {
        if(isFree)
        {
            if(myPlant==null)
            {
                myPlant = Instantiate<Plant>(seeds, myCenter, Quaternion.identity, tileMap.GetComponent<Transform>());
                myPlant.MyGround = this;
            }
            else
            {
                myPlant.newPlant();
                myPlant.gameObject.SetActive(true);
            }
          
            isFree = false;
            
        }
       
    }

    public void WetGround()
    {
        isWet = true;
        base.sprite = wetGround;
        

    }
    public void DryGround()
    {
        isWet = false;
        base.sprite = dryGround;
        
    }

   



    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        base.RefreshTile(position, tilemap);
    }

    [MenuItem("Assets/MyGame/GroundTile")]
    public static void CreateGroundTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Ground Tile", "New Ground Tile", "Asset", "Save Ground Tile", "Assets/Tilemap/Tiles");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<GroundTile>(), path);
    }
}
