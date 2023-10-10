using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private bool isRight;
	[SerializeField] private GameCircle firstCircle;
	private float objectWidth;
	private Vector2 screenBounds;
	
	public void Initialize()
	{
		var position = new Vector2(transform.position.x, firstCircle.transform.position.y);
		transform.position = position;
	}
	
	private void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		objectWidth = spriteRenderer.bounds.size.x / 2;
		if (isRight)
		{
			transform.position = new Vector2(screenBounds.x + objectWidth, transform.position.y);
		}
		else
		{
			transform.position = new Vector2(-screenBounds.x - objectWidth, transform.position.y);
		}
		
		Initialize();
		
		player.CircleChanged += OnPlayerCircleChanged;
	}
	
	private void OnPlayerCircleChanged(GameCircle circle)
	{
		var position = new Vector2(transform.position.x, circle.transform.position.y);
		transform.position = position;
	}
	
	private void OnDestroy()
	{
		player.CircleChanged -= OnPlayerCircleChanged;
	}
}
