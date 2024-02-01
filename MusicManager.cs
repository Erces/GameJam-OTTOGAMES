using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public static MusicManager Instance;

	private AudioSource audioSource;

	[SerializeField]
	private AudioClip buttonClip;

	[SerializeField]
	private AudioClip throwStoneClip;

	[SerializeField]
	private AudioClip buyBarricadeClip;

	[SerializeField]
	private AudioClip afterDeathClip;

	[SerializeField]
	private AudioClip placeBarricadeClip;

	[SerializeField]
	private AudioClip destroyBuildingClip;

	[SerializeField]
	private AudioClip destroyBullDozerClip;

	private void Start()
	{
		Instance = GetComponent<MusicManager>();
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayButtonClip()
	{
		audioSource.clip = buttonClip;
		PlaySound();
	}

	public void PlayThrowStoneClip()
	{
		audioSource.clip = throwStoneClip;
		PlaySound();
	}

	public void BuyBarricadeClip()
	{
		audioSource.clip = buyBarricadeClip;
		PlaySound();
	}

	public void playAfterDeathClip()
	{
		audioSource.clip = afterDeathClip;
		PlaySound();
	}

	public void PlayPlaceBarricadeClip()
	{
		audioSource.clip = placeBarricadeClip;
		PlaySound();
	}

	public void PlayDestroyBuildingClip()
	{
		audioSource.clip = destroyBuildingClip;
		PlaySound();
	}

	public void PlayDestroyBulldozerClip()
	{
		audioSource.clip = destroyBullDozerClip;
		PlaySound();
	}

	private void PlaySound()
	{
		if (PlayerPrefs.GetInt("Sound") == 0)
		{
			audioSource.Play();
		}
		else if (PlayerPrefs.GetInt("Sound") == -1)
		{
			audioSource.Stop();
		}
	}
}
