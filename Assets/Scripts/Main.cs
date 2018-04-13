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

	public void StartGame()
	{
		var playerPrefab = Resources.Load(Player.PrefabPath) as GameObject;
		var player = Instantiate(playerPrefab, transform).GetComponent<Player>();
		player.SetData("ネス", "...", 100);

		var enemyPrefab = Resources.Load(Enemy.PrefabPath) as GameObject;
		var enemy = Instantiate(enemyPrefab, transform).GetComponent<Enemy>();
		enemy.SetData("スターマン", "オマエハ 英雄デハナク タダノムシケラナノダ！", 1000);

		//var ness = new Player();
		//ness.Name = "ネス";
		//ness.TalkMessage = "...";
		//var paula = new Player();
		//paula.Name = "ポーラ";
		//paula.TalkMessage = "…わたしもちょっとくらいならアブナイ超能力を使えるのよ。";
		//var jeff = new Player();
		//jeff.Name = "ジェフ";
		//jeff.TalkMessage = "説明はいらないよ。ぼくはジェフ。きみたちに呼ばれて来たんだ。";
		//var poo = new Player();
		//poo.Name = "プー";
		//poo.TalkMessage = "おれの名はプー。君達と共に戦う者だ。おれはネスに従う。";
		//var starman = new Enemy();
		//starman.Name = "スターマン";
		//starman.TalkMessage = "オマエハ 英雄デハナク タダノムシケラナノダ！";
		//var masterBelch = new Enemy();
		//masterBelch.Name = "ゲップー";
		//masterBelch.TalkMessage = "ゲボゲボゲボ、ゲボゲボ、ゲローーップ！";
		//var mama = new NPC();
		//mama.Name = "ママ";
		//mama.TalkMessage = "イエーイ！ファイト！ファ・イ・ト♪";
		//var mrSaturn = new NPC();
		//mrSaturn.Name = "どせいさん";
		//mrSaturn.TalkMessage = "ぽえ〜ん";
	}
}
