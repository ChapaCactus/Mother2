using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public List<Character> characters = new List<Character>();

	private void Start()
	{
		StartGame();
	}

	private Character CreateCharacter(string prefabPath, Transform parent, string name, string talkMessage, int power)
	{
		var prefab = Resources.Load(prefabPath) as GameObject;
		var character = Instantiate(prefab, parent).GetComponent<Character>();
		character.SetData(name, talkMessage, power);

		return character;
	}

	public void StartGame()
	{
		var ness = CreateCharacter(Player.PrefabPath, transform, "ネス", "...", 100) as Player;
		var paula = CreateCharacter(Player.PrefabPath, transform, "ポーラ", "…わたしもちょっとくらいならアブナイ超能力を使えるのよ。", 100) as Player;
		var jeff = CreateCharacter(Player.PrefabPath, transform, "ジェフ", "説明はいらないよ。ぼくはジェフ。きみたちに呼ばれて来たんだ。", 100) as Player;
		var poo = CreateCharacter(Player.PrefabPath, transform, "プー", "おれの名はプー。君達と共に戦う者だ。おれはネスに従う。", 100) as Player;
		var starman = CreateCharacter(Enemy.PrefabPath, transform, "スターマン", "オマエハ 英雄デハナク タダノムシケラナノダ！", 1000) as Enemy;
		var masterBelch = CreateCharacter(Enemy.PrefabPath, transform, "ゲップー", "ゲボゲボゲボ、ゲボゲボ、ゲローーップ！", 1000) as Enemy;
		var mama = CreateCharacter(NPC.PrefabPath, transform, "ママ", "イエーイ！ファイト！ファ・イ・ト♪", 0) as NPC;
		var mrSaturn = CreateCharacter(NPC.PrefabPath, transform, "どせいさん", "ぽえ〜ん", 0) as NPC;
	}
}
