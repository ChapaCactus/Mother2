using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : Character, IDamageable, ITalkable, IParty
{
	public static readonly string PrefabPath = "Prefabs/Player";

	private const float MoveBuff = 0.05f;

	private void Update()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");
		var movement = new Vector2(h * MoveBuff, v * MoveBuff);

		if (movement != Vector2.zero)
		{
			Move(movement);
		}
	}

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

	private void Move(Vector2 movement)
	{
		transform.localPosition += (Vector3)movement;
		CharacterManager.I.onPlayerMoved(movement);
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

	protected override void Prepare()
	{
	}
}
