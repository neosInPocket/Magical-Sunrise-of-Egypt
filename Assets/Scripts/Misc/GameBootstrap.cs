using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
	[SerializeField] private MainMenuController _mainMenuController;
	[SerializeField] private GameController _gameController;
 	void Start()
	{
		_mainMenuController.Initialize();
	}
}
