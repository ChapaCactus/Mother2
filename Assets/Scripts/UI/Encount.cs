using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Encount : SingletonMonoBehaviour<Encount>
{
    [SerializeField]
    private Animator _animator;

    private Action _onEnd;

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
        if (_onEnd == null) return;

        _onEnd();
    }

    public void SetOnEnd(Action onEnd)
    {
        _onEnd = onEnd;
    }
}
