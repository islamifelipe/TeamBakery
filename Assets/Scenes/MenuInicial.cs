using UnityEngine;
using System.Collections;

public class MenuInicial : MonoBehaviour {

	public Texture t1;
	
	// Use this for initialization
	void Start(){	
	}
	
	// Update is called once per frame
	void Update(){	
	}
	void OnGUI(){
		if (GUI.Button (new Rect (500, 523, 80, 50), "Creditos")) {
				Application.LoadLevel ("creditos");
		}
		if (GUI.Button (new Rect (500, 355, 80, 50), "Fases")) {
				Application.LoadLevel ("Fases");
		}
		if (GUI.Button (new Rect (500, 467, 80, 50), "Opçoes")) {
			//Application.LoadLevel ("opçoes");			
		}			
	}
}
