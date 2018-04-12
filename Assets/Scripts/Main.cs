using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	private void Start()
	{
		StartGame();
	}

	public void StartGame()
	{
		var ness = new Ness();
		ness.Name = "ネス";
		ness.TalkMessage = "...";
		var paula = new Paula();
		paula.Name = "ポーラ";
		paula.TalkMessage = "…わたしもちょっとくらいならアブナイ超能力を使えるのよ。";
		var jeff = new Jeff();
		jeff.Name = "ジェフ";
		jeff.TalkMessage = "説明はいらないよ。ぼくはジェフ。きみたちに呼ばれて来たんだ。";
		var poo = new Poo();
		poo.Name = "プー";
		poo.TalkMessage = "おれの名はプー。君達と共に戦う者だ。おれはネスに従う。";
		var starman = new Starman();
		starman.Name = "スターマン";
		starman.TalkMessage = "オマエハ 英雄デハナク タダノムシケラナノダ！";
		var masterBelch = new MasterBelch();
		masterBelch.Name = "ゲップー";
		masterBelch.TalkMessage = "ゲボゲボゲボ、ゲボゲボ、ゲローーップ！";
		var mama = new Mama();
		mama.Name = "ママ";
		mama.TalkMessage = "イエーイ！ファイト！ファ・イ・ト♪";
		var mrSaturn = new MrSaturn();
		mrSaturn.Name = "どせいさん";
		mrSaturn.TalkMessage = "ぽえ〜ん";
	}
}
