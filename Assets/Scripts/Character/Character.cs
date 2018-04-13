using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Character : MonoBehaviour
{
	public string Name { get; set; }
	public string TalkMessage { get; set; }

	public bool IsRunning { get; set; }

	public virtual void Talk()
	{
		Debug.Log(Name + " 「" + TalkMessage + "」");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var damageable = collision.GetComponent<IDamageable>();
		if (damageable != null)
			damageable.Damage(10);

		var talkable = collision.GetComponent<ITalkable>();
		if (talkable != null)
			talkable.Talk();
	}
}
