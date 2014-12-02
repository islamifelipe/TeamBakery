using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject b1, b2, b3, b4;
	private GameObject mb1, mb2, mb3, mb4;	
	
	// Use this for initialization
	void Start () {
		mb1 = (GameObject) Instantiate(b1, new Vector3(0, 0, -1), Quaternion.identity);
		mb2 = (GameObject) Instantiate(b2, transform.position, Quaternion.identity);
		mb3 = (GameObject) Instantiate(b3, transform.position, Quaternion.identity);
		mb4 = (GameObject) Instantiate(b4, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
