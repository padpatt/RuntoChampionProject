using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public static CameraController cmC;
	public PlayerController theCamera;
	public GameObject FindscriptJa;
	private Vector3 lastCameraPosition;
	private float distanceToMove;
	// Use this for initialization
	void Start () {
		lastCameraPosition = theCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (theCamera == null) {
			FindscriptJa = GameObject.Find ("Player");
			theCamera = FindscriptJa.GetComponent<PlayerController> ();
			Debug.Log (theCamera);
		}
		distanceToMove = theCamera.transform.position.x - lastCameraPosition.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		lastCameraPosition = theCamera.transform.position;
	}
}
