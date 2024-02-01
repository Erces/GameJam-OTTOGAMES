using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
	private CharacterController karakter;

	private NavMeshAgent ajan;

	private GameObject player;

	private PlayerManager pm;

	[SerializeField]
	private GameObject rockPrefab;

	private GameObject _target;

	private Animator anim;

	private bool isRunning;

	private Rigidbody rb;

	private Animator[] chars;

	private float shootRange = 30f;

	private float shootSpeed = 1f;

	private void Start()
	{
		chars = base.transform.GetComponentsInChildren<Animator>();
		int num = Random.Range(0, chars.Length);
		Animator[] array = chars;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
		chars[num].gameObject.SetActive(value: true);
		anim = chars[num];
		player = GameObject.FindGameObjectWithTag("Player");
		pm = base.transform.GetComponentInParent<PlayerManager>();
		pm.AddCharacter(this);
		karakter = GetComponent<CharacterController>();
		ajan = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (isRunning && ajan.remainingDistance < 2f)
		{
			anim.SetBool("run", value: false);
			isRunning = false;
		}
	}

	public void WalkTarget(Vector3 target)
	{
		target.y = 0f;
		target.y = base.transform.localScale.y / 2f;
		base.transform.Rotate(target.x, target.y, target.z);
		ajan.SetDestination(target);
		anim.SetBool("run", value: true);
		isRunning = true;
	}

	public void ShootTarget(GameObject target)
	{
		_target = target;
		Invoke("shoot", Random.Range(0f, 0.4f));
		ScoreManager.Instance.ThrowingStone();
		MusicManager.Instance.PlayThrowStoneClip();
	}

	private void shoot()
	{
		Vector3 target = _target.transform.position;
		if (Vector3.Distance(_target.transform.position, base.transform.position) > shootRange)
		{
			target = Vector3.Normalize(_target.transform.position - base.transform.position) * (shootRange + Random.Range((0f - shootRange) * 0.1f, shootRange * 0.1f));
		}
		Object.Instantiate(rockPrefab, base.transform.position, Quaternion.identity).GetComponent<RockThrow>().SetTarget(target);
	}
}
