using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Encount : SingletonMonoBehaviour<Encount>
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Animator _animator;

    private Action _onEnd;

    private void Awake()
    {
        Assert.IsNotNull(_image);
        Assert.IsNotNull(_animator);
    }

    public void Play()
    {
        if (_animator == null) return;

        _image.enabled = true;

        _animator.Play("Encount");
    }

    public void Hide()
    {
        _image.enabled = false;
        _animator.Play("Empty");
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
