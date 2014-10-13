using UnityEngine;
using System.Collections;

public class CupCakeAI : MonoBehaviour {

	public float speed, area;
	private float initPos;
	public bool right;
	private Vector3 initialScale;

	// Use this for initialization
	void Start () {
		initPos = this.transform.position.x;
		right = false;
		initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > initPos + area) {
			right = true;
			transform.localScale = new Vector3 (-initialScale.x, initialScale.y, initialScale.z);
		}
		else if (this.transform.position.x < initPos - area) {
			right = false;
			transform.localScale = initialScale;
		}
		if(right) rigidbody2D.velocity = new Vector2 (-speed, rigidbody2D.velocity.y);
		else rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
	}
}