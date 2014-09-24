using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxVerSpeed, jumpStrenght, sprintBonus;
	public Vector3 initialScale;
	public Animator PCAnim;
	private float horSpeed, verSpeed;
	private bool jump;

	void OnCollisionEnter(Collision col){// Checa se Mario esta no chao
		if(col.gameObject.name == "floor") jump = true;
		else jump = false;
		Debug.Log("Hello", gameObject);
	}

	// Use this for initialization
	void Start(){
		Debug.Log("Hello", gameObject);
		initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		horSpeed = 0;
		verSpeed = rigidbody2D.velocity.y;
		if(Input.GetKey(KeyCode.RightArrow)){ // Andar para a direita
			horSpeed = maxVerSpeed;
			if(Input.GetKey(KeyCode.LeftShift)) horSpeed *= sprintBonus;
			transform.localScale = initialScale;
		}
		else if(Input.GetKey (KeyCode.LeftArrow)){ // Andar para a esquerda
			horSpeed = -maxVerSpeed;
			if(Input.GetKey(KeyCode.LeftShift)) horSpeed *= sprintBonus;
			transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
		}
		if (Input.GetKey (KeyCode.UpArrow) && jump == true){ // Salto
			verSpeed = jumpStrenght;
			rigidbody2D.AddForce(new Vector2(0, jumpStrenght));
		}
		PCAnim.SetFloat ("horSpeed", Mathf.Abs(horSpeed));
		PCAnim.SetFloat ("verSpeed", Mathf.Abs(verSpeed));

		rigidbody2D.velocity = new Vector2 (horSpeed, rigidbody2D.velocity.y);
	}
}
