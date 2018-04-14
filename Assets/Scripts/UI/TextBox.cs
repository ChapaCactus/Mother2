using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

[RequireComponent(typeof(CanvasGroup))]
public class TextBox : SingletonMonoBehaviour<TextBox>
{
	[SerializeField]
	private Text _text;

	private CanvasGroup _canvasGroup;

	private float _showTimer;

	private const float DefaultTimerSec = 3f;

	public bool IsRunningTimer { get { return (_showTimer > 0); } }

	private void Awake()
	{
		Assert.IsTrue(gameObject.activeSelf);

		_canvasGroup = GetComponent<CanvasGroup>();

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
		if (_canvasGroup == null) return;
		if (_text == null) return;

		_canvasGroup.alpha = visible ? 1 : 0;
		_canvasGroup.interactable = visible;
		_canvasGroup.blocksRaycasts = visible;

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
