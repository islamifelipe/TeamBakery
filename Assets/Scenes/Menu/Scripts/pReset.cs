using UnityEngine;
using System.Collections;

public class pReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDown(){
		Application.LoadLevel(Application.loadedLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
