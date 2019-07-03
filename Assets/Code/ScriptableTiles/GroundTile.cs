using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GroundTile : Tile
{
    public bool isWet;

    public Sprite wetGround;
    public ITilemap tileMap;

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        this.tileMap = tilemap;
        return base.StartUp(position, tilemap, go);
    }

    public void WetGround()
    {
        isWet = true;
        base.sprite = wetGround;

    }
    public void DryGround()
    {
        isWet = false;
        base.sprite = default;
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
