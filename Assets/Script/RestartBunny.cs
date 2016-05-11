using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartBunny : MonoBehaviour {
	public string mainMenuLevel;
	public void RestartGame ()
	{
		FindObjectOfType<GameManager> ().Reset();

	}

	// Update is called once per frame
	public void QuitToMain()
	{
		//Application.LoadLevel(mainMenuLevel);
		SceneManager.LoadScene ("mainmenu");
	}
}
