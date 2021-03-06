﻿using UnityEngine;
using System.Collections;

public class projInfo : MonoBehaviour {

	public float lifeTimer;
	public int damage;

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy") col.gameObject.GetComponent<enemyInfo>().health -= damage;
		if (col.gameObject.tag != "Player") Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		lifeTimer -= Time.deltaTime;
		if (lifeTimer < 0f) Destroy (this.gameObject);
	}
}
