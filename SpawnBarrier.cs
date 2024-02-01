using UnityEngine;

public class SpawnBarrier : MonoBehaviour
{
	public static SpawnBarrier Instance;

	[SerializeField]
	private GameObject barrierOneObject;

	[SerializeField]
	private GameObject barrierTwoObject;

	[SerializeField]
	private GameObject barrierThreeObject;

	[SerializeField]
	private GameObject spawnerOne;

	[SerializeField]
	private GameObject spawnerTwo;

	[SerializeField]
	private GameObject spawnerThree;

	private bool barrierOne;

	private bool barrierTwo;

	private bool barrierThree;

	public bool openSpawnerOne;

	public bool openSpawnerTwo;

	public bool openSpawnerThree;

	public bool spawn;

	private void Start()
	{
		Instance = GetComponent<SpawnBarrier>();
	}

	private void Update()
	{
		if (openSpawnerOne)
		{
			spawnerOne.SetActive(value: true);
			spawnerTwo.SetActive(value: false);
			spawnerThree.SetActive(value: false);
			openSpawnerOne = false;
			spawn = true;
			barrierOne = true;
			barrierTwo = false;
			barrierThree = false;
		}
		else if (openSpawnerTwo)
		{
			spawnerOne.SetActive(value: false);
			spawnerTwo.SetActive(value: true);
			spawnerThree.SetActive(value: false);
			openSpawnerTwo = false;
			spawn = true;
			barrierOne = false;
			barrierTwo = true;
			barrierThree = false;
		}
		else if (openSpawnerThree)
		{
			spawnerOne.SetActive(value: false);
			spawnerTwo.SetActive(value: false);
			spawnerThree.SetActive(value: true);
			openSpawnerThree = false;
			spawn = true;
			barrierOne = false;
			barrierTwo = false;
			barrierThree = true;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && barrierOne)
		{
			spawnerOne.transform.Rotate(0f, 0f, 30f, Space.Self);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && barrierOne)
		{
			spawnerOne.transform.Rotate(0f, 0f, -30f, Space.Self);
		}
		if (spawn && Input.GetKeyDown("space") && barrierOne)
		{
			spawnerOne.SetActive(value: false);
			Object.Instantiate(barrierOneObject, spawnerOne.transform.position, spawnerOne.transform.rotation);
			MusicManager.Instance.PlayPlaceBarricadeClip();
			spawn = false;
			barrierOne = false;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && barrierTwo)
		{
			spawnerTwo.transform.Rotate(0f, 0f, 30f, Space.Self);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && barrierTwo)
		{
			spawnerTwo.transform.Rotate(0f, 0f, -30f, Space.Self);
		}
		if (spawn && Input.GetKeyDown("space") && barrierTwo)
		{
			spawnerTwo.SetActive(value: false);
			Object.Instantiate(barrierTwoObject, spawnerTwo.transform.position, spawnerTwo.transform.rotation);
			MusicManager.Instance.PlayPlaceBarricadeClip();
			spawn = false;
			barrierTwo = false;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && barrierThree)
		{
			spawnerThree.transform.Rotate(0f, 0f, 30f, Space.Self);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && barrierThree)
		{
			spawnerThree.transform.Rotate(0f, 0f, -30f, Space.Self);
		}
		if (spawn && Input.GetKeyDown("space") && barrierThree)
		{
			spawnerThree.SetActive(value: false);
			Object.Instantiate(barrierThreeObject, spawnerThree.transform.position, spawnerThree.transform.rotation);
			MusicManager.Instance.PlayPlaceBarricadeClip();
			spawn = false;
			barrierThree = false;
		}
	}

	public void BuyBarrierOne()
	{
		openSpawnerOne = true;
		openSpawnerTwo = false;
		openSpawnerThree = false;
	}

	public void BuyBarrierTwo()
	{
		openSpawnerOne = false;
		openSpawnerTwo = true;
		openSpawnerThree = false;
	}

	public void BuyBarrierThree()
	{
		openSpawnerOne = false;
		openSpawnerTwo = false;
		openSpawnerThree = true;
	}
}
