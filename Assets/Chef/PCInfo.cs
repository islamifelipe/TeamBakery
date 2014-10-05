using UnityEngine;
using System.Collections;

public class PCInfo : MonoBehaviour {
	public int health;

	// Use this for initialization
	void Start () {	
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			(GameObject.Find ("mainCam")).transform.parent = null;
			Destroy (gameObject);
			Destroy (GameObject.Find ("HUD"));
		}
	}
}
