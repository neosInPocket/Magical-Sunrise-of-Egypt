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
	[SerializeField] private float launchSpeed;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject effect; 
	[SerializeField] private TrailRenderer trailRenderer;
	private bool isCentered;
	private GameCircle currentCircle;
	private int rotationDirection;
	public SpriteRenderer SpriteRenderer => spriteRenderer;
	public TrailRenderer TrailRenderer => trailRenderer;
	
	public Action<GameCircle> CircleChanged;
	public Action<GameCircle, GameCircle> HeightChanged;
	private float[] rotationSpeeds = new float[4] {70, 55, 40, 25};
	private float rotationSpeed;
	private bool isDead;
	public Action<bool> TakeDamageEvent;
	
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		Touch.onFingerDown += LaunchPlayer;
		
		Initialize();
	}
	
	public void Initialize()
	{
		rotationSpeed = rotationSpeeds[MainMenuController.CurrentRotationSpeedUpgrade];
		SetPlayerInPosition(firstCircle);
	}
	
	private void Update()
	{
		if (!isCentered) return;
		
		transform.RotateAround(currentCircle.transform.position, Vector3.forward * rotationDirection, rotationSpeed * Time.deltaTime);
	}
	
	private void LaunchPlayer(Finger finger)
	{
		if (!isCentered || !GameController._isPlaying) return;
		
		isCentered = false;
		rb.gravityScale = 1;
		rb.AddForce(-transform.up * launchSpeed, ForceMode2D.Impulse);
	}
	
	public void SetPlayerInPosition(GameCircle circle)
	{
		rotationDirection = 1;
		
		currentCircle = circle;
		var positionX = currentCircle.transform.position.x;
		var positionY = currentCircle.transform.position.y - currentCircle.Collider.radius;
		transform.position = new Vector2(positionX, positionY);
		RotatePlayerToTangent(currentCircle.transform);
		isCentered = true;
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<GameCircle>(out GameCircle circle))
		{
			if (circle == currentCircle) return;
			
			rotationDirection *= -1;
			RotatePlayerToTangent(circle.transform);
			HeightChanged?.Invoke(currentCircle, circle);
			CircleChanged?.Invoke(circle);
			currentCircle = circle;
			rb.gravityScale = 0;
			rb.velocity = Vector2.zero;
			isCentered = true;
			AudioEvent.RaiseEvent(AudioTypes.CircleChanged);
			return;
		}
		
		if (collider.TryGetComponent<BottomDeathZoneTrigger>(out BottomDeathZoneTrigger trigger))
		{
			rb.gravityScale = 0;
			rb.velocity = Vector2.zero;
			rb.angularVelocity = 0;
			trailRenderer.Clear();
			PlayDeath(false);
			return;
		}
		
		if (collider.TryGetComponent<DeathZoneTrigger>(out DeathZoneTrigger deathZoneTrigger))
		{
			rb.gravityScale = 0;
			rb.velocity = Vector2.zero;
			rb.angularVelocity = 0;
			trailRenderer.Clear();
			PlayDeath(false);
			return;
		}
		
		if (collider.TryGetComponent<CoinBehaviour>(out CoinBehaviour coin))
		{
			if (coin.isCollected) return;
			GameController._points += 2;
			TakeDamageEvent?.Invoke(true);
			coin.PlayDeath();
		}
	}
	
	public void PlayDeath(bool isWon)
	{
		if (isWon)
		{
			StartCoroutine(PlayEffect());
			return;
		}
		
		TakeDamageEvent?.Invoke(false);
		if (GameController.lives != 0)
		{
			StopCoroutine(TakeDamage());
			StartCoroutine(TakeDamage());
			return;
		}
		
		if (GameController.lives == 0)
		{
			StartCoroutine(PlayEffect());
		}
	}
	
	private IEnumerator PlayEffect()
	{
		isDead = true;
		spriteRenderer.color = new Color(0, 0, 0, 0);
		var deathEffect = Instantiate(effect, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(1f);
		Destroy(deathEffect);
	}
	
	private IEnumerator TakeDamage()
	{
		SetPlayerInPosition(currentCircle);
		trailRenderer.Clear();
		
		for (int i = 0; i < 9; i++)
		{
			spriteRenderer.color = spriteRenderer.color = new Color(1f, 1f, 1f, 0);
			trailRenderer.startColor = new Color(1f, 0f, 0f, 0f);
			trailRenderer.endColor = new Color(1f, 1f, 0f, 0f);
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			trailRenderer.startColor = new Color(0.254902f, 0.1686275f, 0.972549f, 1f);
			trailRenderer.endColor = new Color(1f, 0, 0, 1f);
			yield return new WaitForSeconds(0.1f);
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
