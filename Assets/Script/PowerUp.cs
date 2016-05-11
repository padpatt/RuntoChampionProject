using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;

	public float powerupLength;
	private PowerUpManager thePowerupManager;

	public Sprite[] powerupSprites;

	void Start () {
	
		thePowerupManager = FindObjectOfType<PowerUpManager> ();

	}
	void Awake()
	{
		int powerupSelector = Random.Range(0,2);
		switch (powerupSelector)
		{
		case 0: doublePoints = true;
			break;
		case 1: safeMode = true;
			break;
		}

		GetComponent<SpriteRenderer>().sprite = powerupSprites [powerupSelector];
	} 

	// Update is called once per frame
	void Update () {
	


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
		
			thePowerupManager.ActivatePowerup (doublePoints, safeMode, powerupLength);

		}
		gameObject.SetActive (false);

	}
}
