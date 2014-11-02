using UnityEngine;
using System.Collections;

public class cartMovement : MonoBehaviour {
	public float cartSpeed;
	public float jumpStrenght;
	private bool jump;
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "jumpSurface") {
			this.transform.rotation = col.gameObject.transform.rotation;
			jump = true;
		}
	}
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.velocity = new Vector2(cartSpeed, this.rigidbody2D.velocity.y);
		if(Input.GetAxis("Jump") > 0 && jump){
			jump = false;
			rigidbody2D.AddForce(new Vector2(0, jumpStrenght));
		}
	}
}
