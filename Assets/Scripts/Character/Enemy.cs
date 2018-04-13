using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDamageable, ITalkable
{
	public static readonly string PrefabPath = "Prefabs/Enemy";

	public void Damage(int damage)
	{
	}
}
