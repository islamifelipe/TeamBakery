using UnityEngine;	
using System.Collections;

public class PlayerController : MonoBehaviour {

	public AudioClip changeWeaponSound, attackSound;
	public float maxHorSpeed, jumpStrenght, sprintBonus, maxSprintSpeed, sprintFadeSpeed, bounceTest;
	public float horDeacc, horAcc, shakeIntensity;
	public bool attack;
	public int camShake, weaponChoice;
	public Vector3 initialScale;
	public Animator PCAnim;
	private float horSpeed, verSpeed, colliderCenter, colliderSize;
	private bool duck, flip, jump;
	private BoxCollider2D chefCollider;
	private GameObject cam;

	// Use this for initialization
	void Start(){
		initialScale = transform.localScale;
		attack = false;
		chefCollider = collider2D as BoxCollider2D;
		colliderSize = chefCollider.size.y;
		colliderCenter = chefCollider.center.y;
		weaponChoice = 0;
		camShake = 0;
		cam = GameObject.Find ("mainCam");
	}

	void OnCollisionEnter2D(Collision2D col){
		print (col.gameObject.tag);

		if (col.gameObject.tag == "jumpSurface") {
				jump = true;
		}
	}

	// Update is called once per frame
	void Update () {
		duck = false;
		flip = false;
		attack = false;
		if(Mathf.Abs (horSpeed) < horDeacc) horSpeed = 0;
		if(horSpeed > 0) horSpeed -= horDeacc;
		else if(horSpeed < 0) horSpeed += horDeacc;
		verSpeed = rigidbody2D.velocity.y;
		
		if (camShake == 1 || camShake == 2 || camShake == 5 || camShake == 6) {
				cam.transform.position = new Vector3 (cam.transform.position.x, cam.transform.position.y + shakeIntensity, cam.transform.position.z);
				camShake++;
		}
		else if (camShake == 3 || camShake == 4) {
				cam.transform.position = new Vector3 (cam.transform.position.x, cam.transform.position.y + shakeIntensity * 2, cam.transform.position.z);
				camShake++;		
		}
		else if (camShake == 7) camShake = 0;

		if (Input.GetKeyDown(KeyCode.Q)) {
			AudioSource.PlayClipAtPoint(changeWeapon, transform.position);
			if(weaponChoice == 0) weaponChoice = 1;
			else weaponChoice = 0;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			AudioSource.PlayClipAtPoint(changeWeapon, transform.position);
			duck = true;
			chefCollider.size = new Vector2 (chefCollider.size.x, colliderSize-(float)0.4);
			chefCollider.center = new Vector2 (chefCollider.center.x, colliderCenter-(float)0.2);
		}
		else {
			chefCollider.size = new Vector2 (chefCollider.size.x, colliderSize);
			chefCollider.center = new Vector2 (chefCollider.center.x, colliderCenter);
		}
		if (Input.GetAxis ("Attack") > 0 && !duck) {
			AudioSource.PlayClipAtPoint(attackSound, transform.position);
			attack = true;
		}
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
		if(Input.GetAxis("Jump") > 0 && verSpeed == 0 && !duck && jump){ // Salto
			jump = false;
			verSpeed = jumpStrenght;
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
