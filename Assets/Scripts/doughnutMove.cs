using UnityEngine;
using System.Collections;

public class doughnutMove : MonoBehaviour {

	public GameObject doughnut;
	private Vector3 origPos;

	// Use this for initialization
	void Start () {
		origPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = doughnut.transform.position+origPos;
	}
}
