using UnityEngine;
using System.Collections;

public class leverAction1 : MonoBehaviour {

	private bool playerIsOn, move1, move2;
	private Vector3 initPos1, initPos2;
	public GameObject block, underBlock;
	public float distance, speed;
	
	// Use this for initialization
	void Start () {
		playerIsOn = false;
		initPos1 = block.transform.position;
		initPos2 = underBlock.transform.position;
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
			move1 = true;
			move2 = true;
		}
		if(move1 && block.transform.position.y < (initPos1.y + distance)){
			block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y + speed, block.transform.position.z);
		}
		else if(move1 && block.transform.position.y > (initPos1.y + distance)){
			block.transform.position = new Vector3(block.transform.position.x, initPos1.y + distance, block.transform.position.z);
			move1 = false;
		}
		else move1 = false;
		
		if(move2 && underBlock.transform.position.y < (initPos2.y + 2.56f)){
			underBlock.transform.position = new Vector3(underBlock.transform.position.x, underBlock.transform.position.y + speed, underBlock.transform.position.z);
		}
		else if(move2 && underBlock.transform.position.y > (initPos2.y + 2.56f)){
			underBlock.transform.position = new Vector3(underBlock.transform.position.x, initPos2.y + 2.56f, underBlock.transform.position.z);
			move2 = false;
		}
		else move2 = false;
	}
}
