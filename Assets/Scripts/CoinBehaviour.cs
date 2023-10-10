using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
	[SerializeField] private GameObject[] sparkles;
	[SerializeField] private GameObject effect;
	[SerializeField] private SpriteRenderer spriteRenderer;
	public bool isCollected;
	public void PlayDeath()
	{
		isCollected = true;
		StartCoroutine(PlayEffect());
	}
	
	private IEnumerator PlayEffect()
	{
		spriteRenderer.color = new Color(0, 0, 0, 0);
		var deathEffect = Instantiate(effect, transform.position, Quaternion.identity);
		foreach (var sparkle in sparkles)
		{
			Destroy(sparkle.gameObject);
		}
		yield return new WaitForSeconds(1f);
		Destroy(deathEffect);
		Destroy(this.gameObject);
		
		
	}
}
