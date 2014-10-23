using UnityEngine;
using System.Collections;

public class toasterAttack : MonoBehaviour {
	public Animator PCAnim;
	public GameObject proj;
	public float xForce, yForce;
	private bool attack;
	private GameObject clone;

	// Use this for initialization
	void Start () {
		attack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("toasterIdle")) attack = true;
		if (PCAnim.GetCurrentAnimatorStateInfo (0).IsName ("toasterAttack") && attack) {
			clone = (GameObject) Instantiate (proj, transform.position, transform.rotation);
			clone.rigidbody2D.AddForce(new Vector2(xForce, yForce));
			attack = false;
		}
	}
}