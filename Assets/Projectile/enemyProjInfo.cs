﻿using UnityEngine;
using System.Collections;

public class enemyProjInfo : MonoBehaviour {	
	public float lifeTimer;
	public int damage;
	
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PCInfo>().health -= damage;
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update(){
		lifeTimer -= Time.deltaTime;
		if(lifeTimer < 0f) Destroy(this.gameObject);
	}
}
