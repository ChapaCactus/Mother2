using UnityEngine;

public static class SavedataManager
{
    private const string PositionX_Key = "PositionX";
    private const string PositionY_Key = "PositionY";

    private const float PlayerDefaultPositionX = 0.3f;
    private const float PlayerDefaultPositionY = -2.5f;

    public static void SaveLastPosition(Vector3 lastPosition)
    {
        PlayerPrefs.SetFloat(PositionX_Key, lastPosition.x);
        PlayerPrefs.SetFloat(PositionY_Key, lastPosition.y);
    }

    public static Vector2 LoadLastPosition()
    {
        var x = PlayerPrefs.GetFloat(PositionX_Key, PlayerDefaultPositionX);
        var y = PlayerPrefs.GetFloat(PositionY_Key, PlayerDefaultPositionY);
        return new Vector2(x, y);
    }
}
