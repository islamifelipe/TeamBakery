using UnityEngine;
using System.Collections;

public class hazardInfo : MonoBehaviour {
	public int damage;
	public AudioClip hitSound;
	
	void Start () {
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			AudioSource.PlayClipAtPoint(hitSound, transform.position);
			col.gameObject.GetComponent<PCInfo>().health -= damage;
			this.collider2D.enabled = false;
		}
	}
	
	void Update () {
	}
}