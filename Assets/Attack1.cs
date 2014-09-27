using UnityEngine;
using System.Collections;

public class Attack1 : MonoBehaviour {
	public PlayerController attack;
	public bool teste;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){
		if (attack.attack){
			Destroy (col.gameObject);
			print ("DED");
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
