using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Character : MonoBehaviour
{
	[SerializeField]
	private string _charaID = "";

    private SpriteRenderer _renderer;

	public string Name { get { return Master.charaName; } }
	public string TalkMessage { get { return Master.talkMessage; } }

	public int Power { get { return Master.power; } }
	public int HP { get; protected set; }

    public List<SkillMaster> Skills { get { return Master.skills; } } 

    public CharacterMaster Master { get; private set; }

	public bool IsDead { get { return HP <= 0; } }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

		Prepare();
    }

	private void Start()
	{
		var master = LoadMaster(_charaID);
        Master = master;
        SetHP(Master.hp);
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
        var parent = ParticleManager.I.transform;
        var particle = Instantiate(particlePrefab, parent);
        particle.transform.localPosition = startPosition;
        particle.Play();
    }

    private void SetHP(int hp)
    {
        HP = hp;
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
