using UnityEngine;
using System.Collections;

public class mainAttack : MonoBehaviour {
	public playerController_2 chef;
	public int damage;
	private enemyInfo enemy;

	void OnTriggerEnter2D(Collider2D col){
		if (chef.attack && col.gameObject.tag == "Enemy") {
			enemy = col.gameObject.GetComponent<enemyInfo>();
			enemy.health -= chef.weaponDamage[chef.weaponChoice] * enemy.weaponDamage[chef.weaponChoice];
			print("damage check");
			print(chef.weaponChoice);
			print(enemy.weaponDamage[chef.weaponChoice]);			
		}
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
