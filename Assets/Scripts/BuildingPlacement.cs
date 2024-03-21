using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildingPlacement : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private TilemapManager tilemapManager;
    [SerializeField] private Building building;
    private Vector2 mousePositionWorld;
    private Building previewBuilding;
    private TilemapData tileData = null;
    public void GetMousePosition(InputAction.CallbackContext _context)
    {
        mousePositionWorld = camera.ScreenToWorldPoint(_context.ReadValue<Vector2>());
        if(previewBuilding != null)
        {
            previewBuilding.transform.position = (Vector3Int)tilemapManager.GetTilePosition(mousePositionWorld);
        }
        tileData = tilemapManager.GetTileData(mousePositionWorld);
    }

    public void ValidateBuilding(InputAction.CallbackContext _context)
    {
        if(_context.performed)
        {
            if (tileData != null && tileData.IsValid)
            {
                tileData.Building = previewBuilding;
                previewBuilding.ActivateBuilding();
                previewBuilding = null;
                tileData = null;
                
                InstantiatePreview(building); 
            }
        }
    }

    private void Start()
    {
        InstantiatePreview(building); 
    }

    private void InstantiatePreview(Building _building)
    {
        previewBuilding = Instantiate(_building, mousePositionWorld, Quaternion.identity);
    }
}
