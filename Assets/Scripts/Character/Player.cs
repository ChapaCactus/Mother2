using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : Character, IDamageable, ITalkable, IParty
{
    [SerializeField]
    private List<Friend> _friends;

    public static readonly string PrefabPath = "Prefabs/Player";

    private const float MoveBuff = 0.03f;

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        var movement = new Vector3(h * MoveBuff, v * MoveBuff, 0);

        if (movement != Vector3.zero)
        {
            Move(movement);
        }
    }

    public void Damage(int damage)
    {
        if (IsDead) return;

        HP -= damage;
        Debug.Log(Name + "が、" + damage + "を受けた");

        if (IsDead)
        {
            HP = 0;
            Debug.Log(Name + "は、力尽きた。");
        }
    }

    private void Move(Vector3 movement)
    {
        transform.localPosition += movement;
        CharacterManager.I.onPlayerMoved(movement);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<IDamageable>();
        if (damageable != null && !(damageable is IParty))
        { 
            Encount.I.Play(() =>
            {
                damageable.Damage(Power);
                Encount.I.Hide();
            });
        }

        var talkable = collision.GetComponent<ITalkable>();
        if (talkable != null && !(talkable is IParty))
            talkable.Talk();
    }

    protected override void Prepare()
    {
        Assert.IsNotNull(_friends);
    }
}
