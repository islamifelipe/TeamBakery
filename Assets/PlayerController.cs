using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxVelocity, jumpStrenght;
	public Vector3 InitialScale;
	private float Velocity;
	public Animator myAnim;

	// Use this for initialization
	void Start () {
	
		InitialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
		Velocity = 0;

		if(Input.GetKey(KeyCode.RightArrow)){
			Velocity = maxVelocity;				
			transform.localScale = InitialScale;

		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			Velocity = -1*maxVelocity;	
			transform.localScale = new Vector3(InitialScale.x*-1, InitialScale.y, InitialScale.z);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
				
			rigidbody2D.AddForce(new Vector2(0, jumpStrenght));
		}

		rigidbody2D.velocity = new Vector2 (Velocity, rigidbody2D.velocity.y);

		myAnim.SetFloat ("Velocity", Mathf.Abs(Velocity));

	}
}
