using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private GameObject dozerPrefab;

	private GameObject[] spawnPoints;

	private float spawnDelay = 9f;

	public bool oneTimePlay;

	private IEnumerator coroutine;

	private GameObject[] houses;

	public static GameManager Instance;

	private bool isDead;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		houses = GameObject.FindGameObjectsWithTag("House");
		coroutine = spawnEnemy(spawnDelay);
		StartCoroutine(coroutine);
	}

	private void Update()
	{
	}

	private IEnumerator spawnEnemy(float delay)
	{
		while (!isDead)
		{
			int num = Random.Range(0, spawnPoints.Length);
			Object.Instantiate(dozerPrefab, spawnPoints[num].transform.position, Quaternion.identity);
			yield return new WaitForSeconds(delay);
		}
	}

	public void chackHouse()
	{
		isDead = true;
		int num = 0;
		GameObject[] array = houses;
		foreach (GameObject gameObject in array)
		{
			Debug.Log("house transform " + gameObject.transform.position);
			if (gameObject.activeSelf)
			{
				isDead = false;
				num++;
			}
		}
		Debug.Log("house left " + num);
		if (isDead)
		{
			GameInterFace.Instance.OpenDeathMenu();
			oneTimePlay = true;
		}
	}
}
