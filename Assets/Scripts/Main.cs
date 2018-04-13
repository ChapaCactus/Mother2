using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

	private void Start()
	{
		StartGame();
	}

	private Character CreateCharacter(string prefabPath, Transform parent, string masterID)
	{
		var master = MasterLoader.LoadCharaMaster(masterID);
		var prefab = Resources.Load(prefabPath) as GameObject;
		var character = Instantiate(prefab, parent).GetComponent<Character>();
		character.SetData(master.charaName, master.talkMessage, master.power, master.hp);
        character.SetSprite(master.charaSprite);

		return character;
	}

	public void StartGame()
	{
		var ness = CreateCharacter(Player.PrefabPath, transform, "Ness") as Player;
		var paula = CreateCharacter(Friend.PrefabPath, transform, "Paula") as Friend;
		var jeff = CreateCharacter(Friend.PrefabPath, transform, "Jeff") as Friend;
		var poo = CreateCharacter(Friend.PrefabPath, transform, "Poo") as Friend;
		var starman = CreateCharacter(Enemy.PrefabPath, transform, "Starman") as Enemy;
		var masterBelch = CreateCharacter(Enemy.PrefabPath, transform, "MasterBelch") as Enemy;
		var mama = CreateCharacter(NPC.PrefabPath, transform, "Mama") as NPC;
		var mrSaturn = CreateCharacter(NPC.PrefabPath, transform, "MrSaturn") as NPC;
	}
}
