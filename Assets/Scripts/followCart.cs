using UnityEngine;
using System.Collections;

public class followCart : MonoBehaviour {
	public GameObject cart;
	
	void Start () {
	}
	
	void Update () {
		this.transform.position = new Vector3(cart.transform.position.x+(float)4, this.transform.position.y, this.transform.position.z);
	}
}
