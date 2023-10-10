using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	[SerializeField] private AudioSource _music;
	[SerializeField] private AudioSource _ballDrop;
	[SerializeField] private AudioSource _coinCollect;
	[SerializeField] private AudioSource _playerDie;
	
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
			case AudioTypes.BallDrop:
				if (_ballDrop == null) return;
				_ballDrop.Play();
				break;
				
			case AudioTypes.CoinCollect:
			if (_coinCollect == null) return;
				_coinCollect.Play();
				break;
				
			case AudioTypes.PlayerDie:
			if (_playerDie == null) return;
				_playerDie.Play();
				break;
		}
		
	}
	
	public void ChangeVolume(float value)
	{
		_music.volume = value;
		GameVolume = value;
	}
}
