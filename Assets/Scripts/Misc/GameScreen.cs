using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
	[SerializeField] private TMP_Text _levelText;
	
	private void Start()
	{
		Refresh();
	}
	
	public void Refresh()
	{
		_levelText.text = "Level " + MainMenuController.CurrentLevel;
	}
}
