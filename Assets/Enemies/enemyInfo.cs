using UnityEngine;
using System.Collections;

public class enemyInfo : MonoBehaviour {
	public int health, damage, horKnockback, verKnockback, liftOff;
	public int[] weaponDamage = new int[10];
	public AudioClip hitSound;

	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			AudioSource.PlayClipAtPoint(hitSound, transform.position);
			col.gameObject.GetComponent<PCInfo>().health -= damage;
			
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
	
	// Update is called once per frame
	void Update () {		
		if (health <= 0)Destroy (gameObject);
	}
}