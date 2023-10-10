using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioEvent
{
    public static event Action<AudioTypes> OnEvent;
	
	public static void RaiseEvent(AudioTypes type)
	{
		OnEvent?.Invoke(type);
	}
}
