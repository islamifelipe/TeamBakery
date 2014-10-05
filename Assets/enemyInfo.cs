using UnityEngine;
using System.Collections;

public class enemyInfo : MonoBehaviour {
	public int health, damage, horKnockback, verKnockback;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<PCInfo>().health -= damage;
			col.gameObject.GetComponent<PlayerController>().camShake = 1;
			//col.gameObject.rigidbody2D.velocity = new Vector2(-horKnockback, verKnockback);
			/*
			Tentando adicionar knockback. Soh o vertical funciona.
			if(col.gameObject.transform.position.x - this.transform.position.x < 0) col.gameObject.rigidbody2D.velocity = new Vector2(horKnockback, col.gameObject.rigidbody2D.velocity.y);
			else col.gameObject.rigidbody2D.velocity = new Vector2(-horKnockback, col.gameObject.rigidbody2D.velocity.y);
			*/
			print ("OUCH");
		}
	}
	
	// Update is called once per frame
	void Update () {		
		if (health <= 0)Destroy (gameObject);
	}
}