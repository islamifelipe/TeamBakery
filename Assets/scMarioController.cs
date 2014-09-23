using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour {

	private Vector3 Escala_original;

	public float MaxVelocity;
	public float MaxVertVel;

	public Animator MineAnimator;

	private float velocity;
	private float vertvel;
	// Use this for initialization
	void Start () {
		velocity = 0;

		Escala_original = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {



		velocity = 0;

		if (Input.GetKey (KeyCode.RightArrow)) {
						
					velocity = MaxVelocity;

			if(transform.localScale.x < 0){
				transform.localScale = Escala_original;

			}
				}

		if (Input.GetKey (KeyCode.LeftArrow)) {
				
			velocity = -1*MaxVelocity;

			if(transform.localScale.x > 0 ){

				transform.localScale = new Vector3 (Escala_original.x*-1, Escala_original.y, Escala_original.z);
			}

		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			
			velocity = -1*MaxVelocity;
			
			if(transform.localScale.x > 0 ){
				
				transform.localScale = new Vector3 (Escala_original.x*-1, Escala_original.y, Escala_original.z);
			}
			
		}
		MineAnimator.SetFloat("Velocity", Mathf.Abs(velocity));

		rigidbody2D.velocity = new Vector2 (velocity, 0);

	}
	
}
