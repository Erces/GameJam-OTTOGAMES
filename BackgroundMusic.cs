using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
	private AudioSource audioSource;

	private bool oneTime;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		if (PlayerPrefs.GetInt("Sound") == 0)
		{
			audioSource.Play();
		}
		else if (PlayerPrefs.GetInt("Sound") == -1)
		{
			audioSource.Stop();
		}
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("Sound") == 0 && oneTime)
		{
			audioSource.Play();
			oneTime = false;
		}
		else if (PlayerPrefs.GetInt("Sound") == -1)
		{
			audioSource.Stop();
			oneTime = true;
		}
		if (GameManager.Instance.oneTimePlay)
		{
			audioSource.Stop();
		}
	}
}
