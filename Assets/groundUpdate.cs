using UnityEngine;
using System.Collections;

public class groundUpdate : MonoBehaviour {
	public bool jump;	
	// Use this for initialization
	void Start () {
	}	
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "jumpSurface") {
			jump = true;
			//AudioSource.PlayClipAtPoint(fallSound, transform.position);
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "jumpSurface") {
			jump = false;
			//AudioSource.PlayClipAtPoint(fallSound, transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
