using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Character : MonoBehaviour
{
	public string Name { get; private set; }
	public string TalkMessage { get; private set; }

	public int Power { get; private set; }
	public int HP { get; private set; }

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
