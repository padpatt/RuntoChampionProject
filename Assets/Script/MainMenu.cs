using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	public string playGameLevel;
	// Use this for initialization
	public void PlayGame () {
		SceneManager.LoadScene ("selectcrt");
		//Application.LoadLevel (playGameLevel);
	}
	public void Level () {
		SceneManager.LoadScene ("endless");
		//Application.LoadLevel (playGameLevel);
	}

	// Update is called once per frame
	public void QuitGame () {
		
		Application.Quit ();
	}
}
