using UnityEngine;
using System.Collections;

public class doughnutIA2 : MonoBehaviour {

	// Use this for initialization
	public float patrollRange;
	public bool Right;
	private Vector3 originalPosition, originalScale;
	private float leftLimit, rightLimit, Velocity, bornTime;
	public float maxVelocity, timeForIdle, timeAsIdle;
	private bool canMove;
	public Animator doughnutAnim;
	private enemySight MySight;
	private GameObject Player;
	public enum doughnutStates{
		Patrolling = 0,
		Iddle = 1,
		RunningTowardsPlayer = 2,
		RunningForLife = 3,
		Dying = 4
	}

	//private doughnutStates currentState;
	//public doughnutStates initialState;

	private IEnumerator idleTime(){
		canMove = false;
		yield return new WaitForSeconds (timeAsIdle);
		canMove = true;
	}


	void Awake(){
		MySight = GetComponent<enemySight> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start () {
		// Guardar posiçao inicial
		originalPosition = transform.localPosition;

		//Estabelecendo limites de patrulha
		leftLimit = originalPosition.x - patrollRange;
		rightLimit = originalPosition.x + patrollRange;

		//Se for colocado algum estado para ser inicial assumir, caso contrario começa patrulhando.

		//currentState = initialState;		


		//Tempo quando nasceu o objeto, sera atualizado a cada idletime.
		bornTime = Time.fixedTime;

		//Guarda a escala original
		originalScale = transform.localScale;

		Right = true;
		canMove = true;
	}//Start()

	void OnTriggerEnter(Collider one){
		
	}

	// Update is called once per frame.
	void Update() {
	
		doughnutAnim.SetFloat("Velocity", 0);
		//Analisa se ja e tempo de ficar idle, se for poe em idle.

		if (MySight.playerInSight) {
						if (Player.transform.position.x - transform.position.x < 0){
						transform.localScale = new Vector3 (originalScale.x * -1, originalScale.y, originalScale.z);
						rigidbody2D.velocity = new Vector2 (maxVelocity * (-1), rigidbody2D.velocity.y);
						doughnutAnim.SetFloat ("Velocity", maxVelocity);
			}else{
				rigidbody2D.velocity = new Vector2(maxVelocity, rigidbody2D.velocity.y);		
				doughnutAnim.SetFloat("Velocity", maxVelocity);
				transform.localScale = originalScale;
			}
			
				} else {


			if (Time.fixedTime > bornTime + timeForIdle) {
				
				rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
				doughnutAnim.SetFloat("Velocity", 0);
				StartCoroutine(idleTime());
				bornTime = Time.fixedTime + timeForIdle;
			}else if (transform.localPosition.x < rightLimit && Right == true && canMove == true) {
				rigidbody2D.velocity = new Vector2(maxVelocity, rigidbody2D.velocity.y);		
				doughnutAnim.SetFloat("Velocity", maxVelocity);
				transform.localScale = originalScale;
			}else if (transform.localPosition.x > leftLimit && canMove == true) {
				Right = false;	
				transform.localScale = new Vector3(originalScale.x*-1, originalScale.y, originalScale.z);
				rigidbody2D.velocity = new Vector2(maxVelocity *(-1), rigidbody2D.velocity.y);
				doughnutAnim.SetFloat("Velocity", maxVelocity);
			}else if(canMove == true){
				Right = true;		
			}
		
		}



	}
}
