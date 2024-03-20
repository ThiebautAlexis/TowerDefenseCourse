using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap = null;
    [SerializeField] private TilemapData[,] datas;
    public void Start()
    {
        datas = new TilemapData[tilemap.size.x, tilemap.size.y];
        Vector3Int _origin = tilemap.origin;
        for (int x = 0; x < tilemap.size.x; x++)
        {
            for (int y = 0; y < tilemap.size.y; y++)
            {
                datas[x, y] = new TilemapData(tilemap.HasTile(_origin + new Vector3Int(x, y, 0)));
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (datas is null) return;
        Vector3 _origin = tilemap.origin + new Vector3(.5f, .5f);
        Vector3 _position; 
        for (int x = 0; x < tilemap.size.x; x++)
        {
            for (int y = 0; y < tilemap.size.y; y++)
            {
                _position = _origin + new Vector3Int(x, y);
                Gizmos.color = datas[x,y].IsValid ? Color.green : Color.red;
                if (datas[x, y].Hover)
                    Gizmos.color = Color.yellow; 
                Gizmos.DrawSphere(_position, .5f); 
            }
        }
    }

    public TilemapData GetTileData(Vector3 _position)
    {
        if(datas is null) return null;
        _position -= tilemap.origin; 
        Vector3Int _intPosition = new Vector3Int((int)_position.x, (int)_position.y, 0);
        if(_intPosition.x >= 0 && 
           _intPosition.y >= 0 && 
           _intPosition.x < datas.GetLength(0) && 
           _intPosition.y < datas.GetLength(1) )
        {
            return datas[_intPosition.x, _intPosition.y]; 
        }
        return null; 
    }

    public Vector2Int GetTilePosition(Vector2 _position)
    {
        return new Vector2Int(Mathf.RoundToInt(_position.x - .5f), Mathf.RoundToInt(_position.y - .5f));
    }
}
