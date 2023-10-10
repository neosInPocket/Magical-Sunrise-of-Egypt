using System;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	public event Action OnFadeEnd;
	
	public void ProcessTakeDamage()
	{
		_animator.SetTrigger("Damage");
	}
	
	public void Fade()
	{
		_animator.SetTrigger("Fade");
	}
	
	public void RaiseEvent()
	{
		OnFadeEnd?.Invoke();
	}
}
