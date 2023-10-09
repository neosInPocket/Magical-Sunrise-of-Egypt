using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCircle : MonoBehaviour
{
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private bool isStatic;
	
	public CircleCollider2D Collider => circleCollider2D;
	private const float minSize = 1;
	private const float maxSize = 3;
	
	private void Start()
	{
		var rndSize = Random.Range(minSize, maxSize);
		spriteRenderer.size = new Vector2(rndSize, rndSize);
		circleCollider2D.radius = rndSize / 2;
		
		var screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		var minX = -screenBounds.x + circleCollider2D.radius + 0.5f;
		var maxX = screenBounds.x - circleCollider2D.radius - 0.5f;
		
		var newPosition = new Vector2(Random.Range(minX, maxX), transform.position.y);
		transform.position = newPosition;
	}
}
