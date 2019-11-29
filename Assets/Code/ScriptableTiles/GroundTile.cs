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

#if UNITY_EDITOR
    [MenuItem("Assets/MyGame/GroundTile")]
    public static void CreateGroundTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Ground Tile", "New Ground Tile", "Asset", "Save Ground Tile", "Assets/Tilemap/Tiles");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<GroundTile>(), path);
    }
#endif
}
