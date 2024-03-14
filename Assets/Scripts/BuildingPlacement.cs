using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingPlacement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private TilemapManager tilemapManager; 

    public void GetMousePosition(InputAction.CallbackContext _context)
    {
        Vector3 _mousePositionWorld = camera.ScreenToWorldPoint(_context.ReadValue<Vector2>());
        Debug.Log(_mousePositionWorld);
        tilemapManager.GetTileData(_mousePositionWorld); 
    }
}
