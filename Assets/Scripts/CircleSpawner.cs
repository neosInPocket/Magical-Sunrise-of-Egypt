using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
	[SerializeField] private GameCircle circlePrefab;
	[SerializeField] private GameCircle firstCircle;
	[SerializeField] private GameCircle secondCircle;
	[SerializeField] private Transform circleContiner;
	private GameCircle currentCircle;
	private GameCircle nextCircle;
	private float dy;
	
	private void Start()
	{
		currentCircle = firstCircle;
		nextCircle = secondCircle;
		
		dy = secondCircle.transform.position.y - firstCircle.transform.position.y;
	}
	
	private void Update()
	{
		if (transform.position.y + dy > nextCircle.transform.position.y)
		{
			currentCircle = nextCircle;
			nextCircle = Instantiate(circlePrefab, new Vector2(0, currentCircle.transform.position.y + dy), Quaternion.identity, circleContiner);
			dy = nextCircle.transform.position.y - currentCircle.transform.position.y;
		}
	}
}
