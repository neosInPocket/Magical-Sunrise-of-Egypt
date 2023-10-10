
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIHealth : MonoBehaviour
{
	[SerializeField] private List<Image> _lifes;
	
	public void RefreshLifes(int value)
	{
		foreach (var life in _lifes)
		{
			life.gameObject.SetActive(false);
		}
		
		for (int i = 0; i < value; i++)
		{
			_lifes[i].gameObject.SetActive(true);
		}
	}
}
