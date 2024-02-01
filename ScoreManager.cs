using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance;

	public int score;

	private float time;

	private int highScore;

	[SerializeField]
	private Text scoreText;

	private void Start()
	{
		Instance = GetComponent<ScoreManager>();
		highScore = PlayerPrefs.GetInt("HighScore");
	}

	private void Update()
	{
		time += 1f * Time.deltaTime;
		TimeScore();
		scoreText.text = string.Concat(score);
	}

	private void TimeScore()
	{
		if (time > 10f)
		{
			time = 0f;
			score += 50;
		}
	}

	public void ThrowingStone()
	{
		score += 2;
	}

	public void BuyBarricade()
	{
		score += 25;
	}

	public void DestroyBulldozer()
	{
		score += 50;
	}

	public void HighScore()
	{
		if (score > highScore)
		{
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}
	}
}
