using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : SingletonMonoBehaviour<TextBox>
{
	[SerializeField]
	private Text _text;

	private float _showTimer;

	private const float DefaultTimerSec = 5f;

	public bool IsRunningTimer { get { return (_showTimer > 0); } }

	private void Awake()
	{
		SetVisible(false);
	}

	private void Update()
	{
		if (!IsRunningTimer) return;

		_showTimer -= Time.deltaTime;

		if (_showTimer <= 0)
		{
			SetVisible(false);
		}
	}

	public void SetVisible(bool visible)
	{
		gameObject.SetActive(visible);

		if (!visible)
			_text.text = "";
	}

	public void SetText(string message)
	{
		if (_text == null) return;
		if (string.IsNullOrEmpty(message)) return;

		_text.text = message;
		StartTimer();
		SetVisible(true);
	}

	private void StartTimer()
	{
		_showTimer = DefaultTimerSec;
	}
}
