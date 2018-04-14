using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : Character, IDamageable, ITalkable, IParty
{
	public static readonly string PrefabPath = "Prefabs/Player";

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

	private void Move(Vector2 move)
	{
		transform.localPosition += (Vector3)move;
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		var damageable = collision.GetComponent<IDamageable>();
		if (damageable != null && !(damageable is IParty))
			damageable.Damage(Power);

		var talkable = collision.GetComponent<ITalkable>();
		if (talkable != null)
			talkable.Talk();
	}
}
