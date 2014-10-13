using UnityEngine;
using System.Collections;

public class Attack1 : MonoBehaviour {
	public PlayerController chef;
	public int[] damage;
	public int attackType;

	void OnTriggerStay2D(Collider2D col){
		print("TRIGGER IS ON");
		if (chef.attack && col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<enemyInfo>().health -= damage[chef.weaponChoice];
		}
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (chef.weaponChoice == 0) attackType = 0;
		else attackType = 1;
	}
}
