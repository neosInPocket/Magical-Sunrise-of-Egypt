using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Player : MonoBehaviour
{
	[SerializeField] private CircleCollider2D mainCircle;
	[SerializeField] private CircleCollider2D playerCollider;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private float launchSpeed;
	private bool isCentered;
	private CircleCollider2D currentCircle;
	
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
		
		transform.RotateAround(currentCircle.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
	}
	
	private void LaunchPlayer(Finger finger)
	{
		rb.gravityScale = 1;
		rb.AddForce(-transform.up * launchSpeed, ForceMode2D.Impulse);
	}
	
	private void SetPlayerInPosition()
	{
		currentCircle = mainCircle;
		var positionX = mainCircle.transform.position.x - mainCircle.radius;
		var positionY = mainCircle.transform.position.y;
		transform.position = new Vector2(positionX, positionY);
		isCentered = true;
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<CircleCollider2D>(out CircleCollider2D circle))
		{
			if (circle == currentCircle) return;
			
			currentCircle = circle;
			rb.gravityScale = 0;
			rb.velocity = Vector2.zero;
		}
	}
	
	private void OnDestroy()
	{
		EnhancedTouchSupport.Disable();
		TouchSimulation.Disable();
	}
}
