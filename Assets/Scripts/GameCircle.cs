using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameCircle : MonoBehaviour
{
	[SerializeField] private CoinBehaviour coinPrefab; 
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private bool isStatic;
	[SerializeField] private bool isSpawnCoin;
	[Range(0, 1f)]
	[SerializeField] private float coinSpawnChance;
	[SerializeField] private Transform coinContainer;
	
	public CircleCollider2D Collider => circleCollider2D;
	private const float minSize = 1;
	private const float maxSize = 3;
	
	private void Start()
	{
		if (!isSpawnCoin) return;
		
		SpawnCoin();
		
		if (isStatic) return;
		
		var rndSize = Random.Range(minSize, maxSize);
		spriteRenderer.size = new Vector2(rndSize, rndSize);
		circleCollider2D.radius = rndSize / 2;
		
		var screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		var minX = -screenBounds.x + circleCollider2D.radius + 0.5f;
		var maxX = screenBounds.x - circleCollider2D.radius - 0.5f;
		
		var newPosition = new Vector2(Random.Range(minX, maxX), transform.position.y);
		transform.position = newPosition;
	}
	
	public void SpawnCoin()
	{
		var random = Random.Range(0, 1f);
		if (coinSpawnChance >= random)
		{
			var randomAngle = Random.Range(0, 2 * Mathf.PI);
			var pointX = Mathf.Cos(randomAngle) * circleCollider2D.radius + transform.position.x;
			var pointY = Mathf.Sin(randomAngle) * circleCollider2D.radius + transform.position.y;
			Instantiate(coinPrefab, new Vector2(pointX, pointY), Quaternion.identity, coinContainer);
		}
	}
}
