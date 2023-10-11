using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
	[SerializeField] private Button _speedButton;
	[SerializeField] private Button _livesButton;
	[SerializeField] private TMP_Text rotSpeedUpgradeAmount;
	[SerializeField] private TMP_Text _maxLivesUpgradeAmount;
	[SerializeField] private TMP_Text _coinsText;
	
	private void Start()
	{
		Refresh();
	}
	
	public void BuyLivesUpgrade()
	{
		var leftCoins = MainMenuController.Coins - 100;
		if (leftCoins < 0)
		{
			return;
		}
		MainMenuController.CurrentLivesUpgrade++;
		MainMenuController.Coins -= 100;
		SaveLoad.Save();
		Refresh();
	}
	
	public void BuyRotationSpeedUpgrade()
	{
		var leftCoins = MainMenuController.Coins - 50;
		if (leftCoins < 0)
		{
			return;
		}
		MainMenuController.CurrentRotationSpeedUpgrade++;
		MainMenuController.Coins -= 50;
		SaveLoad.Save();
		Refresh();
	}
	
	public void Refresh()
	{
		_speedButton.interactable = true;
		_livesButton.interactable = true;
		_coinsText.text = MainMenuController.Coins.ToString();
		rotSpeedUpgradeAmount.text = "Rot. speed upgrade: " + MainMenuController.CurrentRotationSpeedUpgrade.ToString() + "/3";
		_maxLivesUpgradeAmount.text = "Max lives: " + MainMenuController.CurrentLivesUpgrade.ToString() + "/3";
		
		if (MainMenuController.CurrentRotationSpeedUpgrade == 3 || MainMenuController.Coins - 50 < 0)
		{
			_speedButton.interactable = false;
		}
		
		if (MainMenuController.CurrentLivesUpgrade == 3 || MainMenuController.Coins - 100 < 0)
		{
			_livesButton.interactable = false;
		}
	}
}
