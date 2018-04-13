using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Character : MonoBehaviour
{
	public string Name { get; set; }
	public string TalkMessage { get; set; }
	public int Power { get; set; }

	public bool IsRunning { get; set; }

	public virtual void Talk()
	{
		Debug.Log(Name + " 「" + TalkMessage + "」");
	}

	protected abstract void OnTriggerEnter2D(Collider2D collision);
}
