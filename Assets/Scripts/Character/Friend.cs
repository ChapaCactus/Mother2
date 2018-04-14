using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Friend : Character, IDamageable, ITalkable, IParty
{
	[SerializeField]
	private int _followDelay = 0;

	public Queue<Vector2> PlayerMoveCache { get; private set; }

	public static readonly string PrefabPath = "Prefabs/Friend";

	private void OnDisable()
	{
        CharacterManager.I.onPlayerMoved -= OnPlayerMoved;
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

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		var damageable = collision.GetComponent<IDamageable>();
		if (damageable != null && !(damageable is IParty))
			damageable.Damage(Power);
	}

	protected override void Prepare()
	{
		PlayerMoveCache = new Queue<Vector2>();
		for (int x = 0; x < _followDelay; x++)
		{
			PlayerMoveCache.Enqueue(Vector2.zero);
		}

		CharacterManager.I.onPlayerMoved += OnPlayerMoved;
	}

	private void OnPlayerMoved(Vector2 moved)
	{
		PlayerMoveCache.Enqueue(moved);
		var movement = PlayerMoveCache.Dequeue();
		transform.localPosition += (Vector3)movement;
	}
}
