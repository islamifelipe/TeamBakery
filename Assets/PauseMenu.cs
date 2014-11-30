using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GameObject b1, b2, b3;
	
	private GameObject mb1, mb2, mb3;	
	
	// Use this for initialization
	void Start () {
	}
	
	public void MenuSwap (bool pauseStatus){
		if(pauseStatus){
			mb1 = (GameObject) Instantiate(b1, new Vector3(transform.position.x, transform.position.y,-1), Quaternion.identity);
			mb2 = (GameObject) Instantiate(b2, new Vector3(transform.position.x, transform.position.y+1,-1), Quaternion.identity);
			mb3 = (GameObject) Instantiate(b3, new Vector3(transform.position.x, transform.position.y+2,-1), Quaternion.identity);
			Time.timeScale = 0;		
		}
		else{
			Destroy(mb1);
			Destroy(mb2);
			Destroy(mb3);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
