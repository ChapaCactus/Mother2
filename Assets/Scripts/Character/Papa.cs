using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papa : NPC, ITalkable
{
	public override void Talk()
	{
        base.Talk();

        var player = GameObject.FindWithTag(Player.PlayerTag);
        SavePosition(player.transform.localPosition);
	}

	private void SavePosition(Vector3 position)
    {
        var fixedPosition = new Vector3(position.x, position.y, 0);
        SavedataManager.SaveLastPosition(fixedPosition);
    }

    protected override void Prepare()
    {
    }

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
	}
}
