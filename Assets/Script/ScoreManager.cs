using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text ScoreText;
	public Text ScoreTextDM;
	public Text HighScoreText;
	public Text HighScoreTextDM;
	public float timeCounter;
	public float ScoreCount;
	public float HighScoreCount;

	public float pointsPerSecond;
	public bool ScoreIncreasing;

	public bool shouldDouble;
	// Use this for initialization
	void Start () {

		PlayerPrefs.HasKey ("HighScore");

	}

	// Update is called once per frame
	void TimeGame(){
		if (!GameManager.die) {
			timeCounter += Time.deltaTime;
			if (timeCounter >= 1) {
				ScoreCount++;
				timeCounter = 0;
			}
		}

	}

	void Update  () {
		if (ScoreCount > HighScoreCount)
		{
			PlayerPrefs.SetFloat("HighScore",ScoreCount);
			PlayerPrefs.Save();

		}

		ScoreText.text = "Distance: " + Mathf.Round(ScoreCount);
		ScoreTextDM.text = "Your Score: " + Mathf.Round(ScoreCount);
		HighScoreCount = PlayerPrefs.GetFloat("HighScore");
		HighScoreText.text = "HighScore : " + HighScoreCount.ToString();
		HighScoreTextDM.text = "HighScore : " + HighScoreCount.ToString();

	}

	public void AddScore(int pointsToAdd){
		if (shouldDouble) 
		{
			pointsToAdd = pointsToAdd * 2;

		}
		ScoreCount += pointsToAdd;


	}
}
