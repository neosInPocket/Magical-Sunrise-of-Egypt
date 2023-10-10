using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreenWithCoins : MonoBehaviour
{
	[SerializeField] private TMP_Text _coinsText;
	[SerializeField] private CanvasGroup _canvasGroup;
	
	public virtual void Show(int coins)
	{
		_canvasGroup.alpha = 1;
		_canvasGroup.interactable = true;
		_canvasGroup.blocksRaycasts = true;
		_coinsText.text = coins.ToString();
	}
	
	public void Hide()
	{
		_canvasGroup.alpha = 0;
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
		gameObject.SetActive(false);
	}
}
