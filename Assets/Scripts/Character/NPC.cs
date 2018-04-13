using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character, ITalkable
{
	public static readonly string PrefabPath = "Prefabs/NPC";

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
	}
}
