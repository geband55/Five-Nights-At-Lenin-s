using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
	public VideoPlayer videoPlayer;
	public GameObject mainMenu;

	void Start()
	{
		videoPlayer.loopPointReached += OnVideoFinished;
	}

	void OnVideoFinished(VideoPlayer vp)
	{
		mainMenu.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void StartGame(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}	