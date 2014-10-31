using UnityEngine;
using System.Collections;

public class followCart : MonoBehaviour {
	public GameObject cart;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(cart.transform.position.x+(float)3, cart.transform.position.y+(float)1, this.transform.position.z);
	}
}
