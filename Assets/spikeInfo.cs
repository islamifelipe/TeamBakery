using UnityEngine;
using System.Collections;

public class spikeInfo : MonoBehaviour {
	public int damage, verKnockback;
	public AudioClip hitSound;
	private Vector3 velocity;
	
	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			//AudioSource.PlayClipAtPoint(hitSound, transform.position);
			col.gameObject.GetComponent<PCInfo>().health -= damage;
			col.gameObject.rigidbody2D.velocity = new Vector2(col.gameObject.rigidbody2D.velocity.x, verKnockback);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}