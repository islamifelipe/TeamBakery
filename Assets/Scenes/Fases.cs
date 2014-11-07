using UnityEngine;
using System.Collections;

public class Fases : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (350, 470, 60, 60), "Voltar")) {
			Application.LoadLevel("MenuInicial");
		}
		if (GUI.Button (new Rect (280, 210, 80, 90), "Fase 1")) {
			Application.LoadLevel("level1_1");		
			//Nao esqueça de clicar na cena da fase 1, ir ate file>>Build Setting e add current cena
		}
		/*
		if (GUI.Button (new Rect (240, 100, 80, 50), "Fase 2")) {
			//Application.LoadLevel("Fase 2");	
			// idem
		}
		if (GUI.Button (new Rect (80, 200, 80, 50), "Fase 3")) {
			//Application.LoadLevel("Fase 3");	
			// idem
		}
		if (GUI.Button (new Rect (240, 200, 80, 50), "Fase 4")) {
			//Application.LoadLevel("Fase 4");
			// idem
		}
		*/
	}
}
