using UnityEngine;
using System.Collections;

public class projectileAmmoed : MonoBehaviour {	
	public GameObject proj;
	public int ammo;
	public float xForce, yForce;
	private GameObject clone;
	private float initialScale;
	
	void Start () {
	}
	
	void Update () {
		initialScale = this.gameObject.transform.localScale.x;
		if (Input.GetButtonDown("AuxWeapon") && Time.timeScale == 1 && ammo > 0) {
			ammo--;
			clone = (GameObject) Instantiate (proj, transform.position, transform.rotation);
			if(initialScale < 0) clone.rigidbody2D.AddForce(new Vector2(-xForce, yForce));
			else clone.rigidbody2D.AddForce(new Vector2(xForce, yForce));
		}
	}
}