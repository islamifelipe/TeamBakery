using UnityEngine;
using System.Collections;

public class MenuInicial : MonoBehaviour {
	public Texture levelT, optionT, credT, tutorialT;	
	// Use this for initialization
	void Start(){	
	}
	
	// Update is called once per frame
	void Update(){	
	}
	void OnGUI(){
		if (GUI.Button (new Rect (450, 355, 160, 50), levelT)) {
			Application.LoadLevel ("Fases");
		}
		if (GUI.Button (new Rect (450, 415, 160, 50), tutorialT)) {
			Application.LoadLevel ("tutorial");			
		}
		if (GUI.Button (new Rect (450, 475, 160, 50), optionT)) {
			Application.LoadLevel ("opçoes");			
		}	
		if (GUI.Button (new Rect (450, 535, 160, 50), credT)) {
			Application.LoadLevel ("creditos");
		}			
	}
}
