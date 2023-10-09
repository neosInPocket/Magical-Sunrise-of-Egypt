using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Player : MonoBehaviour
{
	[SerializeField] private GameCircle firstCircle;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private float launchSpeed;
	private bool isCentered;
	private GameCircle currentCircle;
	private int rotationDirection;
	
	public Action<GameCircle> CircleChanged;
	public Action<GameCircle, GameCircle> HeightChanged;
	
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		Touch.onFingerDown += LaunchPlayer;
		
		SetPlayerInPosition();
	}
	
	private void Update()
	{
		if (!isCentered) return;
		
		transform.RotateAround(currentCircle.transform.position, Vector3.forward * rotationDirection, rotationSpeed * Time.deltaTime);
	}
	
	private void LaunchPlayer(Finger finger)
	{
		if (!isCentered) return;
		
		isCentered = false;
		rb.gravityScale = 1;
		rb.AddForce(-transform.up * launchSpeed, ForceMode2D.Impulse);
	}
	
	private void SetPlayerInPosition()
	{
		rotationDirection = 1;
		
		currentCircle = firstCircle;
		var positionX = firstCircle.transform.position.x;
		var positionY = firstCircle.transform.position.y - firstCircle.Collider.radius;
		transform.position = new Vector2(positionX, positionY);
		RotatePlayerToTangent(firstCircle.transform);
		isCentered = true;
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent(out GameCircle circle))
		{
			if (circle == currentCircle) return;
			Debug.Log("Circle changed");
			
			rotationDirection *= -1;
			RotatePlayerToTangent(circle.transform);
			HeightChanged?.Invoke(currentCircle, circle);
			CircleChanged?.Invoke(circle);
			currentCircle = circle;
			rb.gravityScale = 0;
			rb.velocity = Vector2.zero;
			isCentered = true;
		}
	}
	
	private void RotatePlayerToTangent(Transform circle)
	{
		transform.right = (circle.position - transform.position) * rotationDirection;
	}
	
	private void OnDestroy()
	{
		EnhancedTouchSupport.Disable();
		TouchSimulation.Disable();
	}
}
