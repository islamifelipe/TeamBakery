﻿using UnityEngine;	
using System.Collections;

public class playerController_3: MonoBehaviour {	
	
	public bool attack;
	public bool[] weaponAvail = new bool[10];
	public int[] weaponDamage = new int[10];
	public int weaponChoice, lastWeaponChoice;
	public float maxHorSpeed, jumpSpeed, sprintBonus, maxSprintSpeed, sprintFadeSpeed, bounceTest, horDeacc, horAcc, shakeIntensity, attackDelay, attackTimer;
	public Animator PCAnim;
	public GameObject mainAttack, weaponHud;
	public GameObject[] weaponIcon = new GameObject[10];
	public AudioClip changeWeaponSound, duckSound, jumpSound, fallSound, pauseSound, unPauseSound;
	public AudioSource pauseMusic, gameMusic;
	public Vector3 initialScale;
	private bool duck, grounded, jump;
	private int intAux;
	private float horSpeed, verSpeed, colliderCenter, colliderSize;
	private BoxCollider2D chefCollider;
	
	void Start(){
		grounded = false;
		initialScale = transform.localScale;
		chefCollider = collider2D as BoxCollider2D;
		colliderSize = chefCollider.size.y;
		colliderCenter = chefCollider.center.y;
		weaponChoice = 1;
		lastWeaponChoice = 1;
		updateWeapons();
	}
	
	// Checagem de colisao com o chao, para poder ativar o salto
	void OnCollisionEnter2D(Collision2D col){
		grounded = true;
	}
	
	void updateWeapons(){
		for(int i = 1; i < 10; i++){
			if(weaponAvail[i]) weaponIcon[i].GetComponent<weaponIcon>().setActive();
			else weaponIcon[i].GetComponent<weaponIcon>().setInactive();
		}
	}
	
	void pauseButton(){
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
	}
	
	void changeWeapon(){
		if (Input.GetKeyDown(KeyCode.Q) && weaponAvail[lastWeaponChoice]) {
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			intAux = weaponChoice;
			weaponChoice = lastWeaponChoice;
			lastWeaponChoice = intAux;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		// Trocar para a arma de ID inferior
		if( Input.GetKeyDown(KeyCode.F)){
			intAux = weaponChoice;
			do{
				weaponChoice--;
				if(weaponChoice < 1) weaponChoice = 9;	
			} while(!weaponAvail[weaponChoice]);
			if(weaponChoice != intAux){
				AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
				lastWeaponChoice = intAux;
			}
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		// Trocar para a arma de ID superior
		if( Input.GetKeyDown(KeyCode.G)){
			intAux = weaponChoice;
			do{
				weaponChoice++;
				if(weaponChoice > 9) weaponChoice = 1;	
			} while(!weaponAvail[weaponChoice]);
			if(weaponChoice != intAux){
				AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
				lastWeaponChoice = intAux;
			}
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha1) && weaponAvail[1] && weaponChoice != 1){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 1;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha2) && weaponAvail[2] && weaponChoice != 2){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 2;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha3) && weaponAvail[3] && weaponChoice != 3){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 3;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha4) && weaponAvail[4] && weaponChoice != 4){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 4;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha5) && weaponAvail[5] && weaponChoice != 5){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 5;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha6) && weaponAvail[6] && weaponChoice != 6){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 6;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha7) && weaponAvail[7] && weaponChoice != 7){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 7;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha8) && weaponAvail[8] && weaponChoice != 8){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 8;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
		if( Input.GetKeyDown(KeyCode.Alpha9) && weaponAvail[9] && weaponChoice != 9){
			AudioSource.PlayClipAtPoint(changeWeaponSound, transform.position);
			lastWeaponChoice = weaponChoice;
			weaponChoice = 9;
			// Show/hide weapon hud
			weaponHud.GetComponent<WeaponHUDControl>().showHud(weaponChoice);
		}
	}
	
	void duckButton(){
		if (Input.GetKey (KeyCode.DownArrow) && grounded && !attack) {
			duck = true;
			chefCollider.size = new Vector2 (chefCollider.size.x, colliderSize-(float)0.4);
			chefCollider.center = new Vector2 (chefCollider.center.x, colliderCenter-(float)0.2);
		}
		else {
			chefCollider.size = new Vector2 (chefCollider.size.x, colliderSize);
			chefCollider.center = new Vector2 (chefCollider.center.x, colliderCenter);
		}
	}
	
	void attackButton(){
		if (Input.GetAxis ("Attack") > 0 && !attack && !duck && grounded) {
			attackTimer = attackDelay;
			mainAttack.collider2D.enabled = true;
			attack = true;
		}
		else if(attackTimer > 0f){
			attackTimer -= Time.deltaTime;
		}
	}
	
	void horizontalMovement(){
		if(Input.GetAxis("Horizontal") > 0 && !duck){
			horSpeed += horAcc;
			if(horSpeed > maxHorSpeed) horSpeed -= sprintFadeSpeed;
			if(Input.GetKey(KeyCode.LeftShift)){
				horSpeed += sprintBonus; // Sprint
				if(horSpeed > maxSprintSpeed) horSpeed = maxSprintSpeed;
			}
			transform.localScale = initialScale;
		}
		// Andar para a esquerda
		else if(Input.GetAxis("Horizontal") < 0 && !duck){
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
		if(Input.GetAxis("Jump") > 0 && grounded && verSpeed == 0){
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
			grounded = false;
			verSpeed = jumpSpeed;
		}
	}
	
	void Update () {
		updateWeapons (); //DEBUG APENAS. REMOVER APOS ADICIONAR ARMAS COLETADAS
		duck = false;
		attack = false;
		horSpeed = rigidbody2D.velocity.x;
		verSpeed = rigidbody2D.velocity.y;
		// Ativa/desativa o collider do ataque
		if(!attack) mainAttack.collider2D.enabled = false;
		
		pauseButton();
		changeWeapon();
		duckButton();
		attackButton();
		horizontalMovement();
		jumpButton();
		
		// Variaveis do Animator
		PCAnim.SetFloat ("horSpeed", Mathf.Abs(horSpeed));
		if(verSpeed != 0) PCAnim.SetBool ("jump", true);
		else PCAnim.SetBool ("jump", false);
		PCAnim.SetBool ("duck", duck);
		PCAnim.SetBool ("attack", attack);
		// Atualizaçao de velocidade
		rigidbody2D.velocity = new Vector2 (horSpeed, verSpeed);
	}
}