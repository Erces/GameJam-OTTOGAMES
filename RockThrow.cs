using DG.Tweening;
using UnityEngine;

public class RockThrow : MonoBehaviour
{
	private float duration = 1f;

	private void Start()
	{
		DOTween.Init();
	}

	private void Update()
	{
	}

	public void SetTarget(Vector3 target)
	{
		duration += Random.Range((0f - duration) * 0.1f, duration * 0.1f);
		base.transform.DOMoveX(target.x, duration).SetEase(Ease.Linear);
		base.transform.DOMoveZ(target.z, duration).SetEase(Ease.Linear);
		base.transform.DOMoveY(target.y, duration / 2f).SetLoops(2, LoopType.Yoyo);
		Invoke("selfDestroy", duration);
	}

	private void selfDestroy()
	{
		Object.Destroy(base.gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		collision.gameObject.CompareTag("Dozer");
	}
}
