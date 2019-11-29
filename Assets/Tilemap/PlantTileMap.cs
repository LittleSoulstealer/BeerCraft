using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantTileMap : MonoBehaviour, IObserver
{
    Tilemap tileMap;
  public GridLayout grid;


    public void Start()
    {
        tileMap = GetComponent<Tilemap>();
        grid = GetComponentInParent<GridLayout>();
        foreach (Vector3Int position in tileMap.cellBounds.allPositionsWithin)
        {
            TileBase t = tileMap.GetTile(position);
            if (!Equals(t, null))
            {
                if (t is GroundTile)
                {
                    GroundTile dt = Instantiate(t) as GroundTile;
                    dt.StartUp(position, dt.tileMap, dt.gameObject);
                    tileMap.SetTile(position, dt);
                }
            }
        }

       
    }

    public void UpdateFromSubject()
    {
        foreach (Vector3Int position in tileMap.cellBounds.allPositionsWithin)
        {
            GroundTile t = (GroundTile)tileMap.GetTile(position);
            if (!Equals(t, null))
            {
                    
            }
        }
        tileMap.RefreshAllTiles();
    }
}

