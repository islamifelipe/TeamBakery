using UnityEngine;
using System.Collections;

public class scPCController : MonoBehaviour {

	private float horSpeed;
	public float horMaxSpeed;
	public Animator controller;
	private float verSpeed;
	public float verMaxSpeed;
	
	// Use this for initialization
	void Start () {
		verSpeed = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			horSpeed = horMaxSpeed;
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			horSpeed = -horMaxSpeed;
		}
		else{
			horSpeed = 0;
		}
		controller.SetFloat ("horSpeed", horSpeed);
		rigidbody2D.velocity = new Vector2 (horSpeed, 0);
	}
}
