using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UIElements;

public class CirclularCameraMovement : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private float cameraSpeed;
	[SerializeField] private float offset;
	private TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
	private bool isStarted;
	private float destination = 0;
	
	private void Start()
	{
		player.HeightChanged += CameraFollow;
	}
	
	private void Update()
	{
		if (!isStarted) return;
		
		if (transform.position.y - offset <= destination)
		{
			var newPosition = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
			transform.position = newPosition;
		}
		else
		{
			isStarted = false;
		}
		
		
	}
	
	private void CameraFollow(GameCircle currentCircle, GameCircle nextCircle)
	{
		destination = nextCircle.transform.position.y;
		isStarted = true;
	}
}
