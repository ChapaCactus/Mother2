using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDamageable, ITalkable
{
	public static readonly string PrefabPath = "Prefabs/Player";

	public void Damage(int damage)
	{
	}
}
