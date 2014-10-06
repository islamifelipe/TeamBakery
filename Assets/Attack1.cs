using UnityEngine;
using System.Collections;

public class Attack1 : MonoBehaviour {
	public PlayerController chef;
	public int[] damage;
	public int attackType;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){
		if (chef.attack && col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<enemyInfo>().health -= damage[chef.weaponChoice];
			print ("ATTACK");
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
