using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
	
	public GameObject proj;
	public float xForce, yForce;
	private GameObject clone;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Tiro")) {
			clone = (GameObject) Instantiate (proj, transform.position, transform.rotation);
			clone.rigidbody2D.AddForce(new Vector2(xForce, yForce));
		}
	}
}
