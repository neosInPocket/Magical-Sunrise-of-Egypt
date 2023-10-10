
using UnityEngine;

public class WinScreen : MonoBehaviour
{
	[SerializeField] private CanvasGroup _canvasGroup;
	
	public virtual void Show()
	{
		_canvasGroup.alpha = 1;
		_canvasGroup.interactable = true;
		_canvasGroup.blocksRaycasts = true;
	}
	
	public void Hide()
	{
		_canvasGroup.alpha = 0;
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
		gameObject.SetActive(false);
	}
}
