using UnityEngine;
using System.Collections;

public class leverAction2 : MonoBehaviour {
	
	private bool playerIsOn;
	private bool[] move = new bool[5];
	private Vector3[] initPos = new Vector3[5];
	public GameObject[] block = new GameObject[5];
	public float speed;
	
	// Use this for initialization
	void Start () {
		playerIsOn = false;
		for(int i = 0; i < 5; i++) initPos[i] = block[i].transform.position;		
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
			for(int i = 0; i < 5; i++) move[i] = true;
		}
		//BLOCK 0
		if(move[0] && block[0].transform.position.x > (initPos[0].x - 2.56f)){
			block[0].transform.position = new Vector3(block[0].transform.position.x - speed, block[0].transform.position.y, block[0].transform.position.z);
		}
		else if(move[0] && block[0].transform.position.x < (initPos[0].x - 2.56f)){
			block[0].transform.position = new Vector3(initPos[0].x - 2.56f, block[0].transform.position.y, block[0].transform.position.z);
			move[0] = false;
		}
		else move[0] = false;
		//BLOCK 1
		if(move[1] && block[1].transform.position.y < (initPos[1].y + 2.56f)){
			block[1].transform.position = new Vector3(block[1].transform.position.x, block[1].transform.position.y + speed, block[1].transform.position.z);
		}
		else if(move[1] && block[1].transform.position.y > (initPos[1].y + 2.56f)){
			block[1].transform.position = new Vector3(block[1].transform.position.x, initPos[1].y + 2.56f, block[1].transform.position.z);
			move[1] = false;
		}
		else move[1] = false;
		//BLOCK 2
		if(move[2] && block[2].transform.position.y > (initPos[2].y - 2.56f)){
			block[2].transform.position = new Vector3(block[2].transform.position.x, block[2].transform.position.y - speed, block[2].transform.position.z);
		}
		else if(move[2] && block[2].transform.position.y < (initPos[2].y - 2.56f)){
			block[2].transform.position = new Vector3(block[2].transform.position.x, initPos[2].y - 2.56f, block[2].transform.position.z);
			move[2] = false;
		}
		else move[2] = false;
		//BLOCK 3
		if(move[3] && block[3].transform.position.x < (initPos[3].x + 2.56f)){
			block[3].transform.position = new Vector3(block[3].transform.position.x + speed, block[3].transform.position.y, block[3].transform.position.z);
		}
		else if(move[3] && block[3].transform.position.x > (initPos[3].x + 2.56f)){
			block[3].transform.position = new Vector3(initPos[3].x + 2.56f, block[3].transform.position.y, block[3].transform.position.z);
			move[3] = false;
		}
		else move[3] = false;
		//BLOCK 4
		if(move[4] && block[4].transform.position.x < (initPos[4].x + 2.56f)){
			block[4].transform.position = new Vector3(block[4].transform.position.x + speed, block[4].transform.position.y, block[4].transform.position.z);
		}
		else if(move[4] && block[4].transform.position.x > (initPos[4].x + 2.56f)){
			block[4].transform.position = new Vector3(initPos[4].x + 2.56f, block[4].transform.position.y, block[4].transform.position.z);
			move[4] = false;
		}
		else move[4] = false;
	}
}
