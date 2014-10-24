using UnityEngine;
using System.Collections;

public class MenuInicial : MonoBehaviour {

	// Use this for initialization
	void Start(){	
	}
	
	// Update is called once per frame
	void Update(){	
	}
	void OnGUI(){
		if (GUI.Button (new Rect (200, 240, 80, 50), "Creditos")) {
				Application.LoadLevel ("creditos");
		}
		if (GUI.Button (new Rect (200, 80, 80, 50), "Fases")) {
				Application.LoadLevel ("Fases");
		}
		if (GUI.Button (new Rect (200, 160, 80, 50), "Opçoes")) {
			//Application.LoadLevel ("opçoes");			
		}			
	}
}
