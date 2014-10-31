using UnityEngine;
using System.Collections;

public class cartMovement : MonoBehaviour {
	public float cartSpeed;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.velocity = new Vector2(cartSpeed, this.rigidbody2D.velocity.y);
	}
}
