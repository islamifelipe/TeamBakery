﻿using UnityEngine;
using System.Collections;

public class arrowIA : MonoBehaviour {
	public GameObject chef;
	public float maxSpeed;
	public float acc;
	private Vector2 scale;
	
	void Start () {
		scale = this.transform.localScale;
	}
	
	void Update () {
		if(Time.timeScale == 1){
			if (chef.transform.position.x < this.transform.position.x && this.rigidbody2D.velocity.x < maxSpeed){
				this.rigidbody2D.AddForce(new Vector2(-acc, 0));
				this.transform.localScale = new Vector2(-scale.x, scale.y);
				this.GetComponent<enemyInfo>().direction = -1;
			}
			else if(this.rigidbody2D.velocity.x > -maxSpeed){
				this.rigidbody2D.AddForce(new Vector2(acc, 0));
				this.transform.localScale = new Vector2(scale.x, scale.y);
				this.GetComponent<enemyInfo>().direction = 1;
			}
		}
	}
}
