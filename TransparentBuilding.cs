using UnityEngine;

public class TransparentBuilding : MonoBehaviour
{
	private GameObject opak;

	private GameObject transparent;

	private void Start()
	{
		opak = base.transform.GetChild(0).gameObject;
		transparent = base.transform.GetChild(1).gameObject;
		opak.SetActive(value: true);
		transparent.SetActive(value: false);
	}

	private void OnMouseEnter()
	{
		opak.SetActive(value: false);
		transparent.SetActive(value: true);
	}

	private void OnMouseExit()
	{
		opak.SetActive(value: true);
		transparent.SetActive(value: false);
	}
}
