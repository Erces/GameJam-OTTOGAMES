using UnityEngine;
using UnityEngine.SceneManagement;

public class RouteManager : MonoBehaviour
{
	public static RouteManager Instance;

	private const string MAIN_MENU_NAME = "Main Menu";

	private const string GAME_NAME = "Game";

	private void Start()
	{
		Instance = GetComponent<RouteManager>();
		Object.DontDestroyOnLoad(base.gameObject);
	}

	public void LoadMainMenu()
	{
		LoadScene("Main Menu");
	}

	public void LoadGame()
	{
		LoadScene("Game");
	}

	private void LoadScene(string name)
	{
		SceneManager.LoadScene(name);
	}
}
