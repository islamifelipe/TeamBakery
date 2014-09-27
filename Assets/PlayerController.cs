using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxHorSpeed, jumpStrenght, sprintBonus, maxSprintSpeed, sprintFadeSpeed, bounceTest;
	public float horDeacc, horAcc;
	public bool attack;
	public Vector3 initialScale;
	public Animator PCAnim;
	private float horSpeed, verSpeed;
	private bool duck, flip, jump;

	// Use this for initialization
	void Start(){
		initialScale = transform.localScale;
		attack = false;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Obstacle" && col.gameObject.transform.position.y < this.transform.position.y) jump = true;
		if (col.gameObject.tag == "Enemy") {
			GameObject cam = GameObject.Find ("MainCam");
			cam.transform.parent = col.gameObject.transform;
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		duck = false;
		flip = false;
		attack = false;

		if (Mathf.Abs (horSpeed) < horDeacc) horSpeed = 0;
		if (horSpeed > 0) horSpeed -= horDeacc;
		else if(horSpeed < 0) horSpeed += horDeacc;
		verSpeed = rigidbody2D.velocity.y;

		if(Input.GetKey (KeyCode.DownArrow)) duck = true;
		if (Input.GetAxis ("Attack") > 0 && !duck) attack = true;
		if(Input.GetAxis("Horizontal") > 0 && !duck){ // Andar para a direita
			if(horSpeed < 0) flip = true;
			horSpeed += horAcc;
			if(horSpeed > +maxHorSpeed) horSpeed -= sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed += sprintBonus; // Sprint
				if(horSpeed > maxSprintSpeed) horSpeed = maxSprintSpeed;
			}
			transform.localScale = initialScale;
		}
		else if(Input.GetAxis("Horizontal") < 0 && !duck){ // Andar para a esquerda
			if(horSpeed > 0) flip = true;
			horSpeed -= horAcc;
			if(horSpeed < -maxHorSpeed) horSpeed += sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed -= sprintBonus; // Sprint
				if(horSpeed < -maxSprintSpeed) horSpeed = -maxSprintSpeed;
			}
			transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
		}
		if(Input.GetAxis("Jump") > 0 && verSpeed < 0.2 && jump && !duck){ // Salto
			jump = false;
			verSpeed = jumpStrenght;
			rigidbody2D.AddForce(new Vector2(0, jumpStrenght));
		}

		PCAnim.SetFloat ("horSpeed", Mathf.Abs(horSpeed));
		PCAnim.SetFloat ("verSpeed", Mathf.Abs(verSpeed));
		PCAnim.SetBool ("duck", duck);
		PCAnim.SetBool ("flip", flip);
		PCAnim.SetBool ("attack", attack);
		rigidbody2D.velocity = new Vector2 (horSpeed, rigidbody2D.velocity.y);

		/*
		// OLD CODE
		if(Input.GetKey (KeyCode.DownArrow)) duck = true;
		if(Input.GetKey(KeyCode.RightArrow)&& duck == false){ // Andar para a direita
			horSpeed = maxVerSpeed;
			if(Input.GetKey(KeyCode.LeftShift)) horSpeed *= sprintBonus; // Sprint
			transform.localScale = initialScale;
		}
		else if(Input.GetKey (KeyCode.LeftArrow) && duck == false){ // Andar para a esquerda
			horSpeed = -maxVerSpeed;
			if(Input.GetKey(KeyCode.LeftShift)) horSpeed *= sprintBonus; // Sprint
			transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
		}
		if(Input.GetKey (KeyCode.UpArrow) && verSpeed == 0 && duck == false){ // Salto
			verSpeed = jumpStrenght;
			rigidbody2D.AddForce(new Vector2(0, jumpStrenght));
		}
		PCAnim.SetFloat ("horSpeed", Mathf.Abs(horSpeed));
		PCAnim.SetFloat ("verSpeed", Mathf.Abs(verSpeed));
		PCAnim.SetBool ("duck", duck);
		rigidbody2D.velocity = new Vector2 (horSpeed, rigidbody2D.velocity.y);
		*/
	}
}
