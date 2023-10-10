using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventHandler : MonoBehaviour
{
	public static event Action<bool> OnEvent;
	
	public static void RaiseEvent(bool value)
	{
		OnEvent?.Invoke(value);
	}
}
