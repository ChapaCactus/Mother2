using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPoint : MonoBehaviour
{
    [SerializeField]
    private Vector2 _nextScene_startPos = Vector2.zero;

    [SerializeField]
    private string _nextSceneName = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            SavedataManager.SaveLastPosition(_nextScene_startPos);
            SavedataManager.SaveIsWarped(true);
            SceneManager.LoadScene(_nextSceneName);
            player.transform.localPosition = _nextScene_startPos;
        }
    }
}
