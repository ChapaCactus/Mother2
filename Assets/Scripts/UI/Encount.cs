using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Encount : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;


    private void Awake()
    {
        Assert.IsNotNull(_animator);
    }

    public void Play()
    {
        if (_animator == null) return;

        _animator.Play("Encount");
    }

    public void OnEnd()
    {
        Debug.Log("エンカウントアニメ終了");
    }
}
