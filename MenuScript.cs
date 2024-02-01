using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
	[SerializeField]
	private Canvas quitMenu;

	[SerializeField]
	private Button startText;

	[SerializeField]
	private Button exitText;

	[SerializeField]
	private Button creditsText;

	[SerializeField]
	private GameObject creditsPanel;

	private void Start()
	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
		creditsText = creditsText.GetComponent<Button>();
		quitMenu.enabled = false;
		creditsPanel.SetActive(value: false);
	}

	public void ExitPress()
	{
		MusicManager.Instance.PlayButtonClip();
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		creditsText.enabled = false;
		creditsPanel.SetActive(value: false);
	}

	public void NoPress()
	{
		MusicManager.Instance.PlayButtonClip();
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		creditsText.enabled = true;
	}

	public void StartGame()
	{
		MusicManager.Instance.PlayButtonClip();
		RouteManager.Instance.LoadGame();
	}

	public void ExitGame()
	{
		MusicManager.Instance.PlayButtonClip();
		Application.Quit();
	}

	public void OpenCredits()
	{
		MusicManager.Instance.PlayButtonClip();
		creditsPanel.SetActive(value: true);
	}
}
