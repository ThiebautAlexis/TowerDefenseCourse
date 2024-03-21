[System.Serializable]
public class TilemapData
{
    public bool Hover = false; 
    public bool IsValid
    {
        get
        {
            return hasTile && building is null; 
        }
    }

    private Building building = null; 
    public Building Building
    {
        get { return building; }
        set 
        {
            if(building == null)
                building = value;
        }
    }


    private int layerIndex = -1;
    private bool hasTile = false;

    public TilemapData(bool _hasTile)
    {
        hasTile = _hasTile; 
    }
}
