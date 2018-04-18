using UnityEngine;
using UnityEngine.SceneManagement;

public static class SavedataManager
{
    private const string IsWarpedKey = "IsWarped";

    private const string QuitSceneNameKey = "QuitSceneName";

    private const string PositionX_Key = "PositionX";
    private const string PositionY_Key = "PositionY";

    public static void SaveIsWarped(bool isWarped)
    {
        PlayerPrefs.SetInt(IsWarpedKey, isWarped ? 1 : 0);
    }

    public static void SaveQuitSceneName(string sceneName)
    {
        PlayerPrefs.SetString(QuitSceneNameKey, sceneName);
    }

    public static void SaveLastPosition(Vector3 lastPosition)
    {
        PlayerPrefs.SetFloat(PositionX_Key, lastPosition.x);
        PlayerPrefs.SetFloat(PositionY_Key, lastPosition.y);
    }

    public static bool LoadIsWarped()
    {
        var isWarpedInt =  PlayerPrefs.GetInt(IsWarpedKey, 0);
        return isWarpedInt == 1;
    }

    public static Vector2 LoadLastPosition()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        var quitSceneName = PlayerPrefs.GetString(QuitSceneNameKey, sceneName);
        var stageMaster = Resources.Load("Masters/Stage/" + sceneName) as StageMaster;

        var isWarped = LoadIsWarped();

        var x = PlayerPrefs.GetFloat(PositionX_Key, stageMaster.startPosition.x);
        var y = PlayerPrefs.GetFloat(PositionY_Key, stageMaster.startPosition.y);

        if(!isWarped && quitSceneName != sceneName)
        {
            x = stageMaster.startPosition.x;
            y = stageMaster.startPosition.y;
        }
        SaveIsWarped(false);

        return new Vector2(x, y);
    }
}
