using UnityEngine;
using System.Collections;

public class JumpThrough : MonoBehaviour {

	public GameObject teste, LasttoExit;
	public float ObjectOriginalPosition, ChefPosition, Position;
	private Collider2D LasttoExitCol;
	private bool onContact, goneOnce;
	// Use this for initialization

	

	void Start () {
		Position = transform.position.y;
		teste = null;
		onContact = false;
		goneOnce = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (onContact == true) {
			ChefPosition = teste.transform.position.y;
			Position = transform.position.y;
			//Physics2D.IgnoreCollision (teste.collider2D, collider2D, false);	
		}


		if (onContact == true && collider2D.transform.position.y + (collider2D.bounds.size.y /2) > teste.collider2D.transform.position.y - (teste.collider2D.bounds.size.y /2)) {
						Physics2D.IgnoreCollision (teste.collider2D, collider2D);	
		} else if (onContact == false && goneOnce == true && collider2D.transform.position.y + (collider2D.bounds.size.y /2) < teste.collider2D.transform.position.y  - 1 - (teste.collider2D.bounds.size.y /2)) {
			Physics2D.IgnoreCollision (teste.collider2D, collider2D, false);
		}


	}



	void OnCollisionEnter2D(Collision2D localCol){
		 
		onContact = true;
		goneOnce = true;
		teste = localCol.collider.gameObject;

		ChefPosition = teste.transform.position.y;

		ObjectOriginalPosition = teste.transform.position.y;

		//Physics2D.IgnoreCollision (localCol.gameObject.collider2D, collider2D);
		//GameObject ObjectonContact = localCol.collider.gameObject;

	
				
	}

	void OnCollisionStay2D(Collision2D localCol){



			//Physics2D.IgnoreCollision (localCol.gameObject.collider2D, collider2D);
		teste = localCol.collider.gameObject;

		ChefPosition = teste.transform.position.y;

	


	}

	void OnCollisionExit2D(Collision2D localCol){
		LasttoExit = localCol.collider.gameObject;
		onContact = false;

	}


	
}
