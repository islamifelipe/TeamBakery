using UnityEngine;	
using System.Collections;

public class PlayerController : MonoBehaviour {

	public AudioClip changeWeaponSound, attackSound, duckSound, jumpSound, fallSound, pauseSound, unPauseSound;
	public AudioSource pauseMusic, gameMusic;
	public float maxHorSpeed, jumpStrenght, sprintBonus, maxSprintSpeed, sprintFadeSpeed, bounceTest;
	public float horDeacc, horAcc, shakeIntensity;
	public bool attack;
	public int camShake, weaponChoice;
	public Vector3 initialScale;
	public Animator PCAnim;
	private float horSpeed, verSpeed, colliderCenter, colliderSize;
	private bool duck, flip, jump;
	private BoxCollider2D chefCollider;

	// Use this for initialization
	void Start(){
		initialScale = transform.localScale;
		attack = false;
		chefCollider = collider2D as BoxCollider2D;
		colliderSize = chefCollider.size.y;
		colliderCenter = chefCollider.center.y;
		weaponChoice = 0;
		camShake = 0;
	}

	void OnCollisionEnter2D(Collision2D col){
		print (col.gameObject.tag);

		if (col.gameObject.tag == "jumpSurface") {
			jump = true;
			AudioSource.PlayClipAtPoint(fallSound, transform.position);
			horDeacc = col.gameObject.collider2D.sharedMaterial.friction;
		}
	}

	// Update is called once per frame
	void Update () {
		duck = false;
		flip = false;
		horSpeed = rigidbody2D.velocity.x;
		if(Mathf.Abs (rigidbody2D.velocity.x) < horDeacc) horSpeed = 0;
		if(rigidbody2D.velocity.x > 0) horSpeed -= horDeacc;
		else if(rigidbody2D.velocity.x < 0) horSpeed += horDeacc;
		verSpeed = rigidbody2D.velocity.y;

		if (PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("ChefAttack1") ||
				PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("ChefAttack2")) attack = true;
		else attack = false;
		if (Input.GetKeyDown (KeyCode.P)) {
			if(Time.timeScale == 0){
				Time.timeScale = 1;
				pauseMusic.Pause();
				gameMusic.Play();
				AudioSource.PlayClipAtPoint(unPauseSound, transform.position);
			}
			else{
				AudioSource.PlayClipAtPoint(pauseSound, transform.position);
				pauseMusic.PlayDelayed(1);
				gameMusic.Pause();
				Time.timeScale = 0;
			}
		}
		if (Input.GetKeyDown(KeyCode.Q)) {
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			if(weaponChoice == 0) weaponChoice = 1;
			else weaponChoice = 0;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			Application.LoadLevel (Application.loadedLevelName);
		}
		if (Input.GetKey (KeyCode.DownArrow) && (
				PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
		 		PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Walking") ||
				PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Duck1") ||
				PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Duck2")
			)) {
			duck = true;
			chefCollider.size = new Vector2 (chefCollider.size.x, colliderSize-(float)0.4);
			chefCollider.center = new Vector2 (chefCollider.center.x, colliderCenter-(float)0.2);
			if(!PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Duck1") && !PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Duck2")){
				AudioSource.PlayClipAtPoint(duckSound, transform.position);
			}
		}
		else {
			chefCollider.size = new Vector2 (chefCollider.size.x, colliderSize);
			chefCollider.center = new Vector2 (chefCollider.center.x, colliderCenter);
		}
		if (Input.GetAxis ("Attack") > 0 && !duck && (
			PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
		   	PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Walking")
			)) {
			AudioSource.PlayClipAtPoint(attackSound, transform.position);
			attack = true;
		}
		if(Input.GetAxis("Horizontal") > 0 && !duck){ // Andar para a direita
			if(rigidbody2D.velocity.x < 0) flip = true;
			horSpeed += horAcc;
			if(horSpeed > maxHorSpeed) horSpeed -= sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed += sprintBonus; // Sprint
				if(horSpeed > maxSprintSpeed) horSpeed = maxSprintSpeed;
			}
			transform.localScale = initialScale;
		}
		else if(Input.GetAxis("Horizontal") < 0 && !duck){ // Andar para a esquerda
			if(rigidbody2D.velocity.x > 0) flip = true;
			horSpeed -= horAcc;
			if(horSpeed < -maxHorSpeed) horSpeed += sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed -= sprintBonus; // Sprint
				if(horSpeed < -maxSprintSpeed) horSpeed = -maxSprintSpeed;
			}
			transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
		}
		if(Input.GetAxis("Jump") > 0 && verSpeed == 0 && !duck && jump){ // Salto
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
			jump = false;
			rigidbody2D.AddForce(new Vector2(0, jumpStrenght));
		}
		PCAnim.SetFloat ("horSpeed", Mathf.Abs(horSpeed));
		PCAnim.SetFloat ("verSpeed", verSpeed);
		PCAnim.SetBool ("duck", duck);
		PCAnim.SetBool ("flip", flip);
		PCAnim.SetBool ("attack", attack);
		PCAnim.SetBool ("jump", jump);
		PCAnim.SetInteger ("attackType", weaponChoice);
		rigidbody2D.velocity = new Vector2 (horSpeed, rigidbody2D.velocity.y);
	}
}
