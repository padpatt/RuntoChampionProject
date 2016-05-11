using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

	public float speed = 0.05f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.die == true) {
			return;
		}
		Vector2 offset = new Vector2 (Time.time * speed, 0);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
