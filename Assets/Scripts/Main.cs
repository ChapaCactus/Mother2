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

	private Character CreateCharacter(string prefabPath, Transform parent, string name, string talkMessage, int power, int hp)
	{
		var prefab = Resources.Load(prefabPath) as GameObject;
		var character = Instantiate(prefab, parent).GetComponent<Character>();
		character.SetData(name, talkMessage, power, hp);

		return character;
	}

	public void StartGame()
	{
		var ness = CreateCharacter(Player.PrefabPath, transform, "ネス", "...", 5, 100) as Player;
		var paula = CreateCharacter(Friend.PrefabPath, transform, "ポーラ", "…わたしもちょっとくらいならアブナイ超能力を使えるのよ。", 2, 60) as Friend;
		var jeff = CreateCharacter(Friend.PrefabPath, transform, "ジェフ", "説明はいらないよ。ぼくはジェフ。きみたちに呼ばれて来たんだ。", 3, 70) as Friend;
		var poo = CreateCharacter(Friend.PrefabPath, transform, "プー", "おれの名はプー。君達と共に戦う者だ。おれはネスに従う。", 7, 120) as Friend;
		//var starman = CreateCharacter(Enemy.PrefabPath, transform, "スターマン", "オマエハ 英雄デハナク タダノムシケラナノダ！", 10, 200) as Enemy;
		//var masterBelch = CreateCharacter(Enemy.PrefabPath, transform, "ゲップー", "ゲボゲボゲボ、ゲボゲボ、ゲローーップ！", 20, 300) as Enemy;
		var mama = CreateCharacter(NPC.PrefabPath, transform, "ママ", "イエーイ！ファイト！ファ・イ・ト♪", 0, 0) as NPC;
		var mrSaturn = CreateCharacter(NPC.PrefabPath, transform, "どせいさん", "ぽえ〜ん", 0, 0) as NPC;
	}
}
