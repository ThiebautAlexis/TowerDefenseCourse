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
                Gizmos.DrawSphere(_position, .5f); 
            }
        }
    }
}
