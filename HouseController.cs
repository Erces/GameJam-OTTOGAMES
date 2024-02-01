using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HouseController : MonoBehaviour
{
	private float maxHealth = 50f;

	private float health;

	public ParticleSystem damageParticles;

	public ParticleSystem crushParticles;

	public ParticleSystem buildParticles;

	private GameObject house;

	private GameObject building;

	public Slider healthBar;

	private void Start()
	{
		health = maxHealth;
		healthBar.gameObject.SetActive(value: false);
		house = base.transform.GetChild(0).gameObject;
		building = base.transform.GetChild(1).gameObject;
	}

	private void Update()
	{
	}

	public float takeDamage()
	{
		healthBar.gameObject.SetActive(value: true);
		house.transform.DOPunchScale(Vector3.one * 0.1f, 1f, 1, 0f).SetEase(Ease.InOutCirc);
		health -= 10f;
		healthBar.value = health / maxHealth;
		damageParticles.Play();
		if (health <= 0f)
		{
			destroyHouse();
		}
		return health;
	}

	private void destroyHouse()
	{
		healthBar.gameObject.SetActive(value: false);
		damageParticles.Stop();
		crushParticles.Play();
		house.transform.DOShakeScale(0.2f);
		Invoke("build", 0.2f);
		MusicManager.Instance.PlayDestroyBuildingClip();
	}

	private void build()
	{
		house.SetActive(value: false);
		building.SetActive(value: true);
		building.transform.DOShakeScale(0.2f);
		buildParticles.Play();
		GameManager.Instance.chackHouse();
	}
}
