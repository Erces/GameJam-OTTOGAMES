using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float speed;

	private void Update()
	{
		base.transform.Rotate(0f, speed * Time.deltaTime, 0f);
	}
}
