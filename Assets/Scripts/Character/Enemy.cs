using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : Character, IDamageable, ITalkable
{
	public static readonly string PrefabPath = "Prefabs/Enemy";

	public void Damage(int damage)
	{
		if (IsDead) return;

		HP -= damage;
		Debug.Log(Name + "が、" + damage + "を受けた");

		if (IsDead)
		{
			HP = 0;
			Debug.Log(Name + "は、力尽きた。");
		}
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		var damageable = collision.GetComponent<IDamageable>();
		if (damageable != null && damageable is IParty)
			damageable.Damage(Power);
	}
}
