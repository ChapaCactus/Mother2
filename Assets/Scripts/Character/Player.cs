using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDamageable, ITalkable
{
	public static readonly string PrefabPath = "Prefabs/Player";

	public void Damage(int damage)
	{
		Debug.Log(Name + "が、" + damage + "を受けた");
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		var damageable = collision.GetComponent<IDamageable>();
		if (damageable != null)
			damageable.Damage(Power);

		var talkable = collision.GetComponent<ITalkable>();
		if (talkable != null)
			talkable.Talk();
	}
}
