using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTileMap;

    private TileBase floorBase;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        //PaintTiles(floorPositions,floorTileMap, )
    }
}
