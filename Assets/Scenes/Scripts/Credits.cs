using UnityEngine;
using System.Collections;

public class creditos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if(GUI.Button (new Rect (80, 100, 80, 50), "Voltar")){
			Application.LoadLevel("MenuInicial");
		}		
	}
}
