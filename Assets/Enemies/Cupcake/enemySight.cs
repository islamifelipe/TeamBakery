using UnityEngine;
using System.Collections;

public class enemySight : MonoBehaviour {

	public float sightView, sightHeight;
	public bool playerInSight;
	private Vector2 direction;
	public Transform BegginingPoint, EndingPoint;
	public GameObject Player, Player1;


	// Use this for initialization
	void Awake () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Player1 = GameObject.FindGameObjectWithTag ("Player1");
	}

	
	void Update(){
		direction = new Vector2 (transform.localScale.x, 0);
		direction.Normalize();
		LineCaster ();
		Debug.DrawLine (BegginingPoint.position, EndingPoint.position, Color.red);
	}


	void LineCaster(){


		playerInSight = false;

		//float teste = 0.5f;

		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y+sightHeight), direction);

		if ( Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y+sightHeight), direction) && (hit.collider.gameObject == Player || hit.collider.gameObject == Player1)  && Mathf.Abs(Player.transform.position.x - transform.position.x) <= sightView) {
			playerInSight = true;		
		}
	}
	

	}
