using UnityEngine;
using System.Collections;

public class mainAttack : MonoBehaviour {
	public playerController_2 chef;
	public int damage;

	void OnTriggerEnter2D(Collider2D col){
		if (chef.attack && col.gameObject.tag == "Enemy") {
			print("mainAttack hit!");
			col.gameObject.GetComponent<enemyInfo>().health -= damage;
		}
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
