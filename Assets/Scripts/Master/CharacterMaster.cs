using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterMaster : ScriptableObject
{
	public string charaName;
	public string talkMessage;

	public List<Sprite> charaSprites;

	public int hp;
	public int power;

    public List<SkillMaster> skills = new List<SkillMaster>();

	public static readonly string MasterPathHeader = "Masters";
}
