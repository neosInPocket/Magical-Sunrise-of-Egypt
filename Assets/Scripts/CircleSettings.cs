using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleSettings", menuName = "Settings")]
public class CircleSettings : ScriptableObject
{
	[SerializeField] private float minSize;
	[SerializeField] private float maxSize;
}
