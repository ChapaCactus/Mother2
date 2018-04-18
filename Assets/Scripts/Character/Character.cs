using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Character : MonoBehaviour
{
	[SerializeField]
	private string _charaID = "";

    private SpriteRenderer _renderer;

	public string Name { get; protected set; }
	public string TalkMessage { get; protected set; }

	public int Power { get; protected set; }
	public int HP { get; protected set; }

    public List<SkillMaster> Skills { get; protected set; } 

	public bool IsDead { get { return HP <= 0; } }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

		Prepare();
    }

	private void Start()
	{
		var master = LoadMaster(_charaID);
		SetData(master.charaName, master.talkMessage, master.power, master.hp);
        SetSkills(master.skills);
        SetSprites(master.charaSprites);
	}

	public virtual void Talk()
	{
		TextBox.I.SetText(TalkMessage);

		Debug.Log(Name + " 「" + TalkMessage + "」");
	}

	protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected void CreateParticle(SkillMaster skill, Vector3 startPosition)
    {
        var particlePrefab = skill.particle.particlePrefab;
        var particle = Instantiate(particlePrefab, transform);
        particle.transform.position = startPosition;
        particle.Play();
    }

	private void SetData(string name, string talkMessage, int power, int hp)
	{
		Name = name;
		TalkMessage = talkMessage;
		Power = power;
		HP = hp;
	}

    private void SetSkills(List<SkillMaster> skills)
    {
        Assert.IsNotNull(skills);
        if (skills == null) return;

        Skills = skills;
    }

	private void SetSprite(Sprite sprite)
	{
        Assert.IsNotNull(_renderer);
        if (_renderer == null) return;

		_renderer.sprite = sprite;
	}

	private void SetSprites(List<Sprite> sprites)
	{
        Assert.IsNotNull(sprites);
        if (sprites == null) return;
        if (sprites.Count == 0) return;

		StartCoroutine(SpriteAnimation(sprites));
	}

	private CharacterMaster LoadMaster(string charaID)
	{
		var master = MasterLoader.LoadCharaMaster(charaID);
		return master;
	}

	private IEnumerator SpriteAnimation(List<Sprite> sprites)
	{
		var playIndex = 0;
		var wait = new WaitForSeconds(0.5f);
		while(true)
		{
            var sprite = sprites[playIndex];
            SetSprite(sprite);
			yield return wait;
			playIndex++;
			if (playIndex > sprites.Count - 1)
				playIndex = 0;
		}
	}

	protected abstract void Prepare();
}
