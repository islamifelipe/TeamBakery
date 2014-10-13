using UnityEngine;
using System.Collections;

public class UpdateHealthHUD : MonoBehaviour {
	public PCInfo chef;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		if (chef.health <= 0) guiText.text = "DED"; 
		else guiText.text = chef.health.ToString();
	}
}
