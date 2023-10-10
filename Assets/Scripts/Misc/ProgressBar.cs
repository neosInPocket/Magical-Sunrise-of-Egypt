using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class ProgressBar : MonoBehaviour
{
	[SerializeField] private Slider _progressBar;
	
	public void Refresh(float progress)
	{
		_progressBar.value = progress;
	}
}
