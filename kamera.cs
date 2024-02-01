using UnityEngine;

public class kamera : MonoBehaviour
{
	public GameObject player;

	private Vector3 mesafe;

	private void Start()
	{
		mesafe = base.transform.position - player.transform.position;
	}

	private void Update()
	{
		base.transform.position = player.transform.position + mesafe;
	}
}
