using UnityEngine;	
using System.Collections;

public class playerController_2: MonoBehaviour {	
	public bool attack;
	public bool[] weaponAvail = new bool[3];
	public int[] weaponDamage = new int[3];
	public int weaponChoice;
	public float maxHorSpeed, jumpStrenght, sprintBonus, maxSprintSpeed, sprintFadeSpeed, bounceTest, horDeacc, horAcc, shakeIntensity, attackDelay, attackTimer;
	public Animator PCAnim;
	public GameObject mainAttack, b1, b2, weaponIcon;
	public AudioClip changeWeaponSound, duckSound, jumpSound, fallSound, pauseSound, unPauseSound;
	public AudioSource pauseMusic, gameMusic;
	public Vector3 initialScale;
	public groundUpdate jumpCheck;
	
	private bool duck, jump;
	private float horSpeed, verSpeed, colliderCenter, colliderSize;
	private BoxCollider2D chefCollider;	
	private GameObject mb1, mb2;
	
	void Start(){	
		attack = false;
		attackTimer = 0f;
		initialScale = transform.localScale;
		chefCollider = collider2D as BoxCollider2D;
		colliderSize = chefCollider.size.y;
		colliderCenter = chefCollider.center.y;
		weaponChoice = 1;
		Time.timeScale = 1;
	}
	
	void pauseButton(){
		if (Input.GetButtonDown("Pause")) {
			if(Time.timeScale == 0){
				Time.timeScale = 1;
				Destroy(mb1);
				Destroy(mb2);
				pauseMusic.Pause();
				gameMusic.Play();
				AudioSource.PlayClipAtPoint(unPauseSound, transform.position);
			}
			else{				
				AudioSource.PlayClipAtPoint(unPauseSound, transform.position);
				pauseMusic.PlayDelayed(1);
				gameMusic.Pause();
				mb1 = (GameObject) Instantiate(b1, new Vector3(transform.position.x, transform.position.y-3,-5), Quaternion.identity);
				mb2 = (GameObject) Instantiate(b2, new Vector3(transform.position.x, transform.position.y+3,-5), Quaternion.identity);
				Time.timeScale = 0;
			}
		}
	}
	
	void changeWeapon(){
		if(Input.GetButtonDown("Swap Left") && Time.timeScale == 1){
			do{
				weaponChoice--;
				if(weaponChoice < 1) weaponChoice = 3;
				weaponIcon.GetComponent<changeWeapon>().swapRight();
			} while(!weaponAvail[weaponChoice]);
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
		}
		if(Input.GetButtonDown("Swap Right") && Time.timeScale == 1){
			do{
				weaponChoice++;
				if(weaponChoice > 9) weaponChoice = 3;
				weaponIcon.GetComponent<changeWeapon>().swapLeft();
			} while(!weaponAvail[weaponChoice]);
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
		}
	}
	
	void duckButton(){
		if (Input.GetButton("Duck")  && Time.timeScale == 1 && (
			PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
			PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Walk") ||
			PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Duck")
			)) {
			duck = true;
			chefCollider.size = new Vector2 (chefCollider.size.x, colliderSize-(float)0.4);
			chefCollider.center = new Vector2 (chefCollider.center.x, colliderCenter-(float)0.2);
			if(!PCAnim.GetCurrentAnimatorStateInfo(0).IsName("Duck")){
				AudioSource.PlayClipAtPoint(duckSound, transform.position);
			}
		}
		else {
			duck = false;
			chefCollider.size = new Vector2 (chefCollider.size.x, colliderSize);
			chefCollider.center = new Vector2 (chefCollider.center.x, colliderCenter);
		}
	}
	
	void attackButton(){
		if (Input.GetButtonDown("MainWeapon")  && Time.timeScale == 1 && !duck && attackTimer <= 0f && (
			PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("Idle") ||
			PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("Walk")
			)) {
			attackTimer = attackDelay;
			mainAttack.collider2D.enabled = true;
			attack = true;
		}
		else if(attackTimer > 0f){
			attackTimer -= Time.deltaTime;
		}
	}
	
	void horizontalMovement(){
		if(Input.GetAxisRaw("Horizontal") > 0  && Time.timeScale == 1 && !duck){
			horSpeed += horAcc;
			if(horSpeed > maxHorSpeed) horSpeed -= sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed += sprintBonus; // Sprint
				if(horSpeed > maxSprintSpeed) horSpeed = maxSprintSpeed;
			}
			transform.localScale = initialScale;
		}
		// Andar para a esquerda
		else if(Input.GetAxisRaw("Horizontal") < 0  && Time.timeScale == 1 && !duck){
			horSpeed -= horAcc;
			if(horSpeed < -maxHorSpeed) horSpeed += sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed -= sprintBonus; // Sprint
				if(horSpeed < -maxSprintSpeed) horSpeed = -maxSprintSpeed;
			}
			transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
		}
	}
	
	void jumpButton(){
		if(Input.GetButtonDown("Jump")  && Time.timeScale == 1 && !duck && jumpCheck.jump){
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
			jumpCheck.jump = false;
			verSpeed = jumpStrenght;
		}
	}
	
	void Update () {
		horSpeed = rigidbody2D.velocity.x;
		verSpeed = rigidbody2D.velocity.y;
		// Ativa/desativa o collider do ataque
		if(!attack) mainAttack.collider2D.enabled = false;
		if(PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) attack = false;
		
		pauseButton();
		changeWeapon();
		duckButton();
		attackButton();
		horizontalMovement();
		jumpButton();
		
		// Variaveis do Animator
		PCAnim.SetFloat ("horSpeed", Mathf.Abs(horSpeed));
		PCAnim.SetBool ("duck", duck);
		PCAnim.SetBool ("attack", attack);
		PCAnim.SetBool ("jump", !jumpCheck.jump);
		// Atualizaçao de velocidade
		rigidbody2D.velocity = new Vector2 (horSpeed, verSpeed);
	}
}
