using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	static public bool die =false;

	public static GameManager gmManager;
	public Transform platformGenerator;
	private Vector3 platformStartPoint;
	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private PlatformDestroy[] platformList;

	public GameObject findScript;
	public ScoreManager theScoreManager;
	public DeathMenu theDeathScreen;

	public bool powerupReset;
	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

	




	}

	// Update is called once per frame
	void Update () {
		if (findScript == null) {
			findScript = GameObject.Find ("Player");
			thePlayer = findScript.GetComponent<PlayerController> ();
		}
	}

	public void RestartGame() 
	{
		

		theScoreManager.ScoreIncreasing = false;

		thePlayer.gameObject.SetActive (false);

		die = false;

		theDeathScreen.gameObject.SetActive (true);
	
		//StartCoroutine ("RestartGameCo");	
	}
	public void restartgameBunny()
	{
		theScoreManager.ScoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		die = false;

	}
	public void Reset()
	{

		theDeathScreen.gameObject.SetActive (false);


		platformList = FindObjectsOfType<PlatformDestroy>();
		for (int i = 0; i < platformList.Length; i++)
		{
			platformList[i].gameObject.SetActive(false);
		}

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);


		theScoreManager.ScoreCount = 0;
		theScoreManager.ScoreIncreasing = false;

		powerupReset = true;
	}
	/*
	public IEnumerator RestartGameCo(){

		theScoreManager.ScoreIncreasing = false;


		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds(0.5f);
		platformList = FindObjectsOfType<PlatformDestroy>();
		for (int i = 0; i < platformList.Length; i++)
		{
			platformList[i].gameObject.SetActive(false);
		}



		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);


		theScoreManager.ScoreCount = 0;
		theScoreManager.ScoreIncreasing = true;

	}*/
}
