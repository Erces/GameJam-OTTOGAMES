using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
	private GameObject[] targetList;

	private GameObject target;

	private GameObject toAttack;

	private bool oneTimeDead;

	private GameObject myModel;

	private float maxHealth = 100f;

	private float health;

	private NavMeshAgent agent;

	private GameObject Barricade;

	private Vector3 startPoint;

	private bool runBack;

	private IEnumerator coroutine;

	private float attackDelay = 1f;

	public Slider healthBar;

	private Canvas canvas;

	public ParticleSystem damageParticle;

	public ParticleSystem smokeParticle;

	private void Start()
	{
		health = maxHealth;
		healthBar.gameObject.SetActive(value: false);
		canvas = healthBar.transform.GetComponentInParent<Canvas>();
		myModel = base.transform.GetChild(0).gameObject;
		agent = base.transform.GetComponent<NavMeshAgent>();
		if (target == null)
		{
			FindTarget();
		}
		startPoint = base.transform.position;
	}

	private void FixedUpdate()
	{
		if (runBack && agent.remainingDistance < 2f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void LateUpdate()
	{
		canvas.transform.LookAt(canvas.transform.position + Vector3.forward);
	}

	private void FindTarget()
	{
		targetList = GameObject.FindGameObjectsWithTag("House");
		float num = Vector3.Distance(base.transform.position, targetList[0].transform.position);
		target = targetList[0];
		for (int i = 1; i < targetList.Length; i++)
		{
			if (Vector3.Distance(base.transform.position, targetList[i].transform.position) < num)
			{
				target = targetList[i];
				num = Vector3.Distance(base.transform.position, targetList[i].transform.position);
			}
		}
		agent.SetDestination(target.transform.position);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Barricade"))
		{
			agent.isStopped = true;
			Barricade = collision.gameObject;
			toAttack = collision.gameObject;
			coroutine = attack(attackDelay);
			StartCoroutine(coroutine);
		}
		else if (collision.gameObject.CompareTag("House"))
		{
			agent.isStopped = true;
			agent.SetDestination(base.transform.position);
			toAttack = collision.gameObject;
			coroutine = attack(attackDelay);
			StartCoroutine(coroutine);
		}
		else if (collision.gameObject.CompareTag("Rock"))
		{
			takeDamage();
		}
	}

	private IEnumerator attack(float _attackDelay)
	{
		while (toAttack != null)
		{
			yield return new WaitForSeconds(_attackDelay);
			myModel.transform.DOPunchPosition(Vector3.forward * 0.3f, attackDelay, 1, 0.1f);
			if (toAttack.gameObject.CompareTag("Barricade"))
			{
				toAttack.GetComponent<BarricadeScript>().takeDamage();
			}
			else if (toAttack.gameObject.CompareTag("House") && toAttack.GetComponentInParent<HouseController>().takeDamage() <= 0f)
			{
				healthBar.gameObject.SetActive(value: false);
				toAttack = null;
				target = null;
				agent.SetDestination(startPoint);
				runBack = true;
				agent.isStopped = false;
			}
		}
	}

	private void punchAnim()
	{
	}

	public void takeDamage()
	{
		healthBar.gameObject.SetActive(value: true);
		health -= 10f;
		healthBar.value = health / maxHealth;
		damageParticle.Play();
		if (health <= 0f)
		{
			agent.SetDestination(startPoint);
			runBack = true;
			smokeParticle.Play();
			agent.isStopped = false;
			healthBar.gameObject.SetActive(value: false);
			toAttack = null;
			if (!oneTimeDead)
			{
				ScoreManager.Instance.DestroyBulldozer();
				GameInterFace.Instance.money += 20;
				MusicManager.Instance.PlayDestroyBulldozerClip();
				oneTimeDead = true;
			}
		}
	}
}
