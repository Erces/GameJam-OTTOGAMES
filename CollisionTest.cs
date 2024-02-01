using UnityEngine;

public class CollisionTest : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		SpawnBarrier.Instance.spawn = false;
	}

	private void OnTriggerExit(Collider other)
	{
		SpawnBarrier.Instance.spawn = true;
	}
}
