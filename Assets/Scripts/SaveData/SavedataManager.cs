using UnityEngine;
using UnityEngine.SceneManagement;

public static class SavedataManager
{
    private const string PositionX_Key = "PositionX";
    private const string PositionY_Key = "PositionY";

    public static void SaveLastPosition(Vector3 lastPosition)
    {
        PlayerPrefs.SetFloat(PositionX_Key, lastPosition.x);
        PlayerPrefs.SetFloat(PositionY_Key, lastPosition.y);
    }

    public static Vector2 LoadLastPosition()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        var stageMaster = Resources.Load("Masters/Stage/" + sceneName) as StageMaster;
        Debug.Log("ロードしたStageMasterの初期位置" + stageMaster.startPosition);

        var x = PlayerPrefs.GetFloat(PositionX_Key, stageMaster.startPosition.x);
        var y = PlayerPrefs.GetFloat(PositionY_Key, stageMaster.startPosition.y);
        return new Vector2(x, y);
    }
}
