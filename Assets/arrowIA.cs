using UnityEngine;
using System.Collections;

public class arrowIA : MonoBehaviour {
	public GameObject chef;
	private bool direction;
	public float maxSpeed;
	public float acc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (chef.transform.position.x < this.transform.position.x && this.rigidbody2D.velocity.x < maxSpeed){
			this.rigidbody2D.AddForce(new Vector2(-acc, 0));	
		}
		else if(this.rigidbody2D.velocity.x > -maxSpeed){
			this.rigidbody2D.AddForce(new Vector2(acc, 0));
		}
	}
}
