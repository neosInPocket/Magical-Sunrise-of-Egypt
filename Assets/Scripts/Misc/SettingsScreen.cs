using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
	[SerializeField] private Scrollbar musicScrollbar;
	[SerializeField] private AudioController audioController;
	
	private void Start()
	{
		musicScrollbar.value = audioController.volume;
	}
	
	public void Refresh()
	{
		musicScrollbar.value = audioController.volume;
	}
}
