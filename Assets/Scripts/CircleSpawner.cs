using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
	[SerializeField] private GameObject circlePrefab;
	[SerializeField] private GameObject firstCircle;
	[SerializeField] private GameObject secondCircle;
	[SerializeField] private Transform circleContiner;
	private GameObject currentCircle;
	private GameObject nextCircle;
	private float dy;
	
	private void Start()
	{
		Initialize();
	}
	
	public void Initialize()
	{
		currentCircle = firstCircle;
		nextCircle = secondCircle;
		
		dy = secondCircle.transform.position.y - firstCircle.transform.position.y;
	}
	
	private void Update()
	{
		if (GameController._isPlaying && transform.position.y + dy > nextCircle.transform.position.y)
		{
			currentCircle = nextCircle;
			nextCircle = Instantiate(circlePrefab, new Vector2(0, currentCircle.transform.position.y + dy), Quaternion.identity, circleContiner);
			dy = nextCircle.transform.position.y - currentCircle.transform.position.y;
		}
	}
}
