using UnityEngine;
using System.Collections;

public class StageControl : MonoBehaviour {
	public int LastIndex;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;	
	}
	
	void Awake(){
		DontDestroyOnLoad(this);
	
	}
	
	void OnLevelWasLoaded(int level){
		if(Application.loadedLevelName != "GameOver"){
			LastIndex = Application.loadedLevel;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
