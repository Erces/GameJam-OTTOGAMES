using UnityEngine;

public class RandomizeHouse : MonoBehaviour
{
	private GameObject homeObj;

	private GameObject propObj;

	private GameObject fenceObj;

	public Transform[] Homes;

	public Transform[] Props;

	public Transform[] Fences;

	private void Start()
	{
		homeObj = base.transform.GetChild(0).gameObject;
		propObj = base.transform.GetChild(1).gameObject;
		fenceObj = base.transform.GetChild(2).gameObject;
		Randomize();
	}

	private void Update()
	{
	}

	private void Randomize()
	{
		Transform[] homes = Homes;
		for (int i = 0; i < homes.Length; i++)
		{
			homes[i].gameObject.SetActive(value: false);
		}
		homes = Props;
		foreach (Transform transform in homes)
		{
			if (Random.Range(0f, 1f) <= 0.5f)
			{
				transform.gameObject.SetActive(value: false);
			}
			else
			{
				transform.gameObject.SetActive(value: true);
			}
		}
		homes = Fences;
		for (int i = 0; i < homes.Length; i++)
		{
			homes[i].gameObject.SetActive(value: false);
		}
		homeObj.SetActive(value: true);
		propObj.SetActive(value: true);
		fenceObj.SetActive(value: true);
		Homes[Random.Range(0, Homes.Length)].gameObject.SetActive(value: true);
		Fences[Random.Range(0, Fences.Length)].gameObject.SetActive(value: true);
	}
}
