using UnityEngine;	
using System.Collections;

public class playerController_2: MonoBehaviour {
	
	public AudioClip changeWeaponSound, duckSound, jumpSound, fallSound, pauseSound, unPauseSound;
	public AudioSource pauseMusic, gameMusic;
	public float maxHorSpeed, jumpStrenght, sprintBonus, maxSprintSpeed, sprintFadeSpeed, bounceTest, horDeacc, horAcc, shakeIntensity;
	public bool attack;
	public int camShake, weaponChoice;
	public Vector3 initialScale;
	public Animator PCAnim;
	public GameObject mainAttack;
	private float horSpeed, verSpeed, colliderCenter, colliderSize;
	private bool duck, jump;
	private BoxCollider2D chefCollider;
	public float attackDelay;
	public float attackTimer;
	
	// Use this for initialization
	void Start(){
		attack = false;
		attackTimer = 0f;
		initialScale = transform.localScale;
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
		}
	}
	
	// Update is called once per frame
	void Update () {
		duck = false;
		horSpeed = rigidbody2D.velocity.x;
		verSpeed = rigidbody2D.velocity.y;
		if(!attack) mainAttack.collider2D.enabled = false;
		if (PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("chefAttack1")) attack = true;
		if (PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) attack = false;

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
		// Ataque
		if (Input.GetAxis ("Attack") > 0 && !duck && attackTimer <= 0f && (
			PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("Idle") ||
			PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("Walking")
			)) {
			attackTimer = attackDelay;
			mainAttack.collider2D.enabled = true;
			attack = true;
		}
		else if(attackTimer > 0f){
			attackTimer -= Time.deltaTime;
		}
		if(Input.GetAxis("Horizontal") > 0 && !duck){ // Andar para a direita
			horSpeed += horAcc;
			if(horSpeed > maxHorSpeed) horSpeed -= sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed += sprintBonus; // Sprint
				if(horSpeed > maxSprintSpeed) horSpeed = maxSprintSpeed;
			}
			transform.localScale = initialScale;
		}
		else if(Input.GetAxis("Horizontal") < 0 && !duck){ // Andar para a esquerda
			horSpeed -= horAcc;
			if(horSpeed < -maxHorSpeed) horSpeed += sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed -= sprintBonus; // Sprint
				if(horSpeed < -maxSprintSpeed) horSpeed = -maxSprintSpeed;
			}
			transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
		}
		if(Input.GetAxis("Jump") > 0 && !duck && jump){ // Salto
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
			jump = false;
			rigidbody2D.AddForce(new Vector2(0, jumpStrenght));
		}
		PCAnim.SetFloat ("horSpeed", Mathf.Abs(horSpeed));
		PCAnim.SetFloat ("verSpeed", verSpeed);
		PCAnim.SetBool ("duck", duck);
		PCAnim.SetBool ("attack", attack);
		PCAnim.SetBool ("jump", jump);
		PCAnim.SetInteger ("attackType", weaponChoice);
		rigidbody2D.velocity = new Vector2 (horSpeed, rigidbody2D.velocity.y);
	}
}
