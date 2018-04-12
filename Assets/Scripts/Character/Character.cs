using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
	public string Name { get; set; }
	public string TalkMessage { get; set; }

	public virtual void Talk()
	{
		Debug.Log(Name + " 「" + TalkMessage + "」");
	}
}
