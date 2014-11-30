using UnityEngine;
using System.Collections;

public class MenuInicial : MonoBehaviour {
	public Texture levelT, optionT, credT, tutorialT;
	public int sizeX, sizeY;
	// Use this for initialization
	void Start(){	
	}
	
	// Update is called once per frame
	void Update(){	
	}
	void OnGUI(){
		GUI.backgroundColor = Color.clear;		
		if (GUI.Button (new Rect(Screen.width/2-sizeX/2, Screen.height/2, sizeX, sizeY), levelT)) {
			Application.LoadLevel ("Fases");
		}
		if (GUI.Button (new Rect(Screen.width/2-sizeX/2, Screen.height/2+50, sizeX, sizeY), tutorialT)) {
			Application.LoadLevel ("tutorial");			
		}
		if (GUI.Button (new Rect(Screen.width/2-sizeX/2, Screen.height/2+100, sizeX, sizeY), optionT)) {
			Application.LoadLevel ("opçoes");			
		}	
		if (GUI.Button (new Rect(Screen.width/2-sizeX/2, Screen.height/2+150, sizeX, sizeY), credT)) {
			Application.LoadLevel ("creditos");
		}			
	}
}
