using UnityEngine;
using System.Collections;

public class leverLift1 : MonoBehaviour {

	public GameObject lift;
	public bool move;
	public float speed, distance;
	private bool playerIsOn, up;
	private Vector3 initPos, finPos;
	public bool surprise;

	// Use this for initialization
	void Start () {
		up = false;
		playerIsOn = false;
		initPos = lift.transform.position;
		finPos = new Vector3(lift.transform.position.x, lift.transform.position.y + distance, lift.transform.position.z);
	}
	
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			print("Player is out");
			playerIsOn = false;
		}
	}	
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			print("Player is near");	
			playerIsOn = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(playerIsOn && Input.GetKeyDown(KeyCode.A)){
			move = true;
			if(up) up = false;
			else up = true;
		}
		if(up){
			if(move && lift.transform.position.y < finPos.y){
				lift.transform.position = new Vector3(lift.transform.position.x, lift.transform.position.y + speed, lift.transform.position.z);
			}
			else if(move && lift.transform.position.y > finPos.y){
				lift.transform.position = new Vector3(lift.transform.position.x, finPos.y, lift.transform.position.z);
				move = false;
			}
			else move = false;
		}
		else{
			if(move && lift.transform.position.y > initPos.y){
				lift.transform.position = new Vector3(lift.transform.position.x, lift.transform.position.y - speed, lift.transform.position.z);
			}
			else if(move && lift.transform.position.y < initPos.y){
				lift.transform.position = new Vector3(lift.transform.position.x, initPos.y, lift.transform.position.z);
				move = false;
			}
			else move = false;
		}
	}
}
