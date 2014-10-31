﻿using UnityEngine;	
using System.Collections;

public class playerController_2: MonoBehaviour {
	
	public AudioClip changeWeaponSound, duckSound, jumpSound, fallSound, pauseSound, unPauseSound;
	public AudioSource pauseMusic, gameMusic;
	public float maxHorSpeed, jumpStrenght, sprintBonus, maxSprintSpeed, sprintFadeSpeed, bounceTest, horDeacc, horAcc, shakeIntensity, attackDelay, attackTimer;
	public bool attack;
	public bool[] weaponAvail = new bool[10];
	public int[] weaponDamage = new int[10];
	public int weaponChoice, lastWeaponChoice;
	public Vector3 initialScale;
	public Animator PCAnim;
	public GameObject mainAttack, weaponHud;
	public GameObject[] weaponIcon = new GameObject[10];
	private int intAux;
	private float horSpeed, verSpeed, colliderCenter, colliderSize;
	private bool duck, jump;
	private BoxCollider2D chefCollider;
	
	void Start(){	
		attack = false;
		attackTimer = 0f;
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
		if (col.gameObject.tag == "jumpSurface") {
			jump = true;
			AudioSource.PlayClipAtPoint(fallSound, transform.position);
		}
	}
	
	void updateWeapons(){
		for(int i = 1; i < 10; i++){
			if(weaponAvail[i]) weaponIcon[i].GetComponent<weaponIcon>().setActive();
			else weaponIcon[i].GetComponent<weaponIcon>().setInactive();
		}
	}
	
	void Update () {
		updateWeapons (); //DEBUG APENAS. REMOVER APOS ADICIONAR ARMAS COLETADAS
		duck = false;
		horSpeed = rigidbody2D.velocity.x;
		verSpeed = rigidbody2D.velocity.y;
		// Ativa/desativa o collider do ataque
		if(!attack) mainAttack.collider2D.enabled = false;
		if (PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("chefAttack1")) attack = true;
		if (PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) attack = false;
		
		// Botao de pausa
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
		// Botao para trocar para a arma anterior
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
		
		// Resetar fase
		if (Input.GetKeyDown (KeyCode.L)) {
			Application.LoadLevel (Application.loadedLevelName);
		}
		// Abaixar
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
		// Andar para a direita
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
		// Salto
		if(Input.GetAxis("Jump") > 0 && !duck && jump){
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
			jump = false;
			rigidbody2D.AddForce(new Vector2(0, jumpStrenght));
		}
		// Variaveis do Animator
		PCAnim.SetFloat ("horSpeed", Mathf.Abs(horSpeed));
		PCAnim.SetFloat ("verSpeed", verSpeed);
		PCAnim.SetBool ("duck", duck);
		PCAnim.SetBool ("attack", attack);
		PCAnim.SetBool ("jump", jump);
		PCAnim.SetInteger ("attackType", weaponChoice);
		// Atualizaçao de velocidade
		rigidbody2D.velocity = new Vector2 (horSpeed, rigidbody2D.velocity.y);
	}
}