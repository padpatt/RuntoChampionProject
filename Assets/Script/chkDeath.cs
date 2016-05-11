using UnityEngine;
using System.Collections;

public class chkDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
	
	}
	void OnCollisionEnter2D (Collision2D other)
	{

		if (other.gameObject.tag == "killbox") {

			GameManager.gmManager.RestartGame();
			PlayerController.pControl.moveSpeed = PlayerController.pControl.moveSpeedStore;

			PlayerController.pControl.speedMilestoneCount = PlayerController.pControl.speedMilestoneCountStore;

		}
	}
}
