using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private const float ZPosition = -10;

	private void Awake()
	{
        Assert.IsNotNull(_player);
	}

	private void Update()
	{
        if (_player == null) return;

        var pos = new Vector3(_player.transform.localPosition.x, _player.transform.localPosition.y, ZPosition);
        transform.localPosition = pos;
	}
}
