﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public string stage;
	public Texture replayT, selectT;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}

	void OnGUI(){
		/*
		if (GUI.Button (new Rect (80, 140, 100, 50), "Menu Inicial")) {
			Application.LoadLevel("MenuInicial");		
		}
		*/
		if (GUI.Button (new Rect (425, 290, 80, 80), selectT)) {
			Application.LoadLevel("Fases");	
		}
		if (GUI.Button (new Rect (565, 290, 80, 80), replayT)) {
			
			int LIndex = GameObject.Find("PreviousStageInfo").GetComponent<StageControl>().LastIndex;
		
			Application.LoadLevel(LIndex);
			/*Application.LoadLevel("CENA");*/
			//Descomente a linha acima e substitua "CENA" pelo nome da cena do jogo correte 
		}
	}
}
