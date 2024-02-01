using UnityEngine;
using UnityEngine.UI;

public class GameInterFace : MonoBehaviour
{
	public static GameInterFace Instance;

	[SerializeField]
	private Image pauseButton;

	[SerializeField]
	private Image playButton;

	[SerializeField]
	private Image soundOn;

	[SerializeField]
	private Image soundOff;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Canvas interFace;

	[SerializeField]
	private Canvas deathScreen;

	[SerializeField]
	private Text deathScoreText;

	[SerializeField]
	private Text highscoreText;

	private bool isPaused;

	private bool isInventoryOpen;

	[SerializeField]
	private Text moneyText;

	[SerializeField]
	private GameObject Market;

	[SerializeField]
	private Image openMarketButton;

	[SerializeField]
	private Image closeMarketButton;

	[SerializeField]
	private GameObject YouHaveNoMoney;

	private float time;

	private bool startTime;

	public int money;

	private void Start()
	{
		Instance = GetComponent<GameInterFace>();
		closeMarketButton.enabled = false;
		Market.SetActive(value: false);
		YouHaveNoMoney.SetActive(value: false);
		playButton.enabled = false;
		if (PlayerPrefs.GetInt("Sound") == -1)
		{
			soundOn.enabled = false;
		}
		else
		{
			soundOff.enabled = false;
		}
		scoreText.text = "0";
		moneyText.text = "0";
		deathScreen.enabled = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && !isInventoryOpen)
		{
			OpenMarket();
			isInventoryOpen = true;
		}
		else if (Input.GetKeyDown(KeyCode.E) && isInventoryOpen)
		{
			CloseMarket();
			isInventoryOpen = false;
		}
		if (Input.GetKeyDown(KeyCode.P) && !isPaused)
		{
			Pause();
			isPaused = true;
		}
		else if (Input.GetKeyDown(KeyCode.P) && isPaused)
		{
			Play();
			isPaused = false;
		}
		moneyText.text = string.Concat(money);
		if (startTime)
		{
			time += 1f * Time.deltaTime;
			if (time > 1f)
			{
				startTime = false;
				time = 0f;
				CloseYouHaveNoMoney();
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GoMainMenu();
		}
	}

	public void Pause()
	{
		MusicManager.Instance.PlayButtonClip();
		Time.timeScale = 0f;
		pauseButton.enabled = false;
		playButton.enabled = true;
	}

	public void Play()
	{
		MusicManager.Instance.PlayButtonClip();
		Time.timeScale = 1f;
		playButton.enabled = false;
		pauseButton.enabled = true;
	}

	public void GoMainMenu()
	{
		MusicManager.Instance.PlayButtonClip();
		RouteManager.Instance.LoadMainMenu();
	}

	public void SoundOff()
	{
		soundOn.enabled = false;
		soundOff.enabled = true;
		PlayerPrefs.SetInt("Sound", -1);
		MusicManager.Instance.PlayButtonClip();
	}

	public void SoundOn()
	{
		soundOn.enabled = true;
		soundOff.enabled = false;
		PlayerPrefs.SetInt("Sound", 0);
		MusicManager.Instance.PlayButtonClip();
	}

	public void OpenDeathMenu()
	{
		deathScoreText.text = scoreText.text;
		ScoreManager.Instance.HighScore();
		highscoreText.text = string.Concat(PlayerPrefs.GetInt("HighScore"));
		interFace.enabled = false;
		deathScreen.enabled = true;
		MusicManager.Instance.playAfterDeathClip();
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
		MusicManager.Instance.PlayButtonClip();
	}

	public void OpenMarket()
	{
		Market.SetActive(value: true);
		closeMarketButton.enabled = true;
		openMarketButton.enabled = false;
		MusicManager.Instance.PlayButtonClip();
	}

	public void CloseMarket()
	{
		Market.SetActive(value: false);
		closeMarketButton.enabled = false;
		openMarketButton.enabled = true;
		MusicManager.Instance.PlayButtonClip();
	}

	public void BuyBarricadeOne()
	{
		MusicManager.Instance.BuyBarricadeClip();
		if (money >= 50)
		{
			Debug.Log("1 Satın Aldnız");
			SpawnBarrier.Instance.BuyBarrierOne();
			money -= 50;
			Debug.Log(money);
			ScoreManager.Instance.BuyBarricade();
		}
		else
		{
			OpenYouHaveNoMoney();
		}
	}

	public void BuyBarricadeTwo()
	{
		MusicManager.Instance.BuyBarricadeClip();
		if (money >= 150)
		{
			Debug.Log("2 Satın Aldnız");
			SpawnBarrier.Instance.BuyBarrierTwo();
			money -= 150;
			Debug.Log(money);
			ScoreManager.Instance.BuyBarricade();
		}
		else
		{
			OpenYouHaveNoMoney();
		}
	}

	public void BuyBarricadeThree()
	{
		MusicManager.Instance.BuyBarricadeClip();
		if (money >= 250)
		{
			Debug.Log("3 Satın Aldnız");
			SpawnBarrier.Instance.BuyBarrierThree();
			money -= 250;
			Debug.Log(money);
			ScoreManager.Instance.BuyBarricade();
		}
		else
		{
			OpenYouHaveNoMoney();
		}
	}

	public void OpenYouHaveNoMoney()
	{
		YouHaveNoMoney.SetActive(value: true);
		startTime = true;
	}

	public void CloseYouHaveNoMoney()
	{
		YouHaveNoMoney.SetActive(value: false);
	}
}
