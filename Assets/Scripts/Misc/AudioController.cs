using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	[SerializeField] private AudioSource _music;
	[SerializeField] private AudioSource circleChanged;
	
	public float volume => _music.volume;
	public static float GameVolume = 1f;
	
	private void Start()
	{
		_music.volume = GameVolume;
		AudioEvent.OnEvent += PlaySound;
	}
	
	private void OnDestroy()
	{
		AudioEvent.OnEvent -= PlaySound;
	}
	
	private void PlaySound(AudioTypes type)
	{
		switch (type)
		{
			case AudioTypes.CircleChanged:
				if (circleChanged == null) return;
				circleChanged.Play();
				break;
		}
		
	}
	
	public void ChangeVolume(float value)
	{
		_music.volume = value;
		GameVolume = value;
	}
}
