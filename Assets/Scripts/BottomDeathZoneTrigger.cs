using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomDeathZoneTrigger : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Player player;
	[SerializeField] private GameCircle firstCircle;
	[SerializeField] private SpriteRenderer spriteRenderer;
	
	public void Initialize()
	{
		var screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		var objectHeight = spriteRenderer.bounds.size.y / 2;
		var position = new Vector2(transform.position.x, Camera.main.transform.position.y - screenBounds.y - objectHeight);
		transform.position = position;
	}
	
	private void Start()
	{
		Initialize();
	}
	
	private void RaiseTrigger(GameCircle circle)
	{
		var screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		var objectHeight = spriteRenderer.bounds.size.y / 2;
		var position = new Vector2(transform.position.x, mainCamera.transform.position.y - screenBounds.y - objectHeight);
		transform.position = position;
	}
	
	private void OnDestroy()
	{
		player.CircleChanged -= RaiseTrigger;
	}
}
