using UnityEngine;
using System.Collections;

public class mainAttack : MonoBehaviour {
	public playerController_2 chef;
	public int damage, liftOff, horKnockback, verKnockback;
	private enemyInfo enemy;

	void OnTriggerEnter2D(Collider2D col){
		if (chef.attack && col.gameObject.tag == "Enemy") {
			enemy = col.gameObject.GetComponent<enemyInfo>();
			enemy.health -= chef.weaponDamage[chef.weaponChoice] * enemy.weaponDamage[chef.weaponChoice];
			print("damage check");
			print(chef.weaponChoice);
			print(enemy.weaponDamage[chef.weaponChoice]);
			
			if(col.gameObject.transform.position.x < this.transform.position.x){
				col.gameObject.transform.position = new Vector2(col.gameObject.transform.position.x-liftOff, col.gameObject.transform.position.y+liftOff);
				col.gameObject.rigidbody2D.velocity = new Vector2(-horKnockback, verKnockback);
			}
			else{
				col.gameObject.transform.position = new Vector2(col.gameObject.transform.position.x+liftOff, col.gameObject.transform.position.y+liftOff);
				col.gameObject.rigidbody2D.velocity = new Vector2(horKnockback, verKnockback);
			}	
		}
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
