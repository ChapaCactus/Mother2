using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonMonoBehaviour<CharacterManager>
{
	public delegate void onPlayerMovedDelegate(Vector2 moved);
	public onPlayerMovedDelegate onPlayerMoved;
}
