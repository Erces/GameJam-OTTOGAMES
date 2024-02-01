using UnityEngine;

public class BarricadeScript : MonoBehaviour
{
	private float health = 50f;

	public ParticleSystem hitParticle;

	public ParticleSystem explodeParticle;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void takeDamage()
	{
		health -= 10f;
		hitParticle.Play();
		if (health <= 0f)
		{
			Object.Destroy(base.gameObject);
			explodeParticle.Play();
		}
	}
}
