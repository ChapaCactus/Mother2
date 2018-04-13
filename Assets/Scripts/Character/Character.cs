using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Character : MonoBehaviour
{
	public string Name { get; protected set; }
	public string TalkMessage { get; protected set; }

	public int Power { get; protected set; }
	public int HP { get; protected set; }

	public bool IsDead { get { return HP <= 0; } }

	public virtual void Talk()
	{
		Debug.Log(Name + " 「" + TalkMessage + "」");
	}

	public void SetData(string name, string talkMessage, int power, int hp)
	{
		Name = name;
		TalkMessage = talkMessage;
		Power = power;
		HP = hp;
	}

	protected abstract void OnTriggerEnter2D(Collider2D collision);
}
