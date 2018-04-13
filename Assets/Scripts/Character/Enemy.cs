using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDamageable, ITalkable
{
	public static readonly string PrefabPath = "Prefabs/Enemy";

	public void Damage(int damage)
	{
		Debug.Log(Name + "が、" + damage + "を受けた");
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		var damageable = collision.GetComponent<IDamageable>();
		if (damageable != null)
			damageable.Damage(Power);
	}
}
