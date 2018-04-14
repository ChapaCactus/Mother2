using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonMonoBehaviour<CharacterManager>
{
	public List<Vector2> PlayerMoveHistory = new List<Vector2>();

	public delegate void onPlayerMovedDelegate(Vector2 moved);
	public onPlayerMovedDelegate onPlayerMoved;
}
