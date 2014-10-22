using UnityEngine;
using System.Collections;

public class parallax: MonoBehaviour {
	public GameObject chef;
	public float weight;
	public int damage;
	private Vector3 initPos;
	
	// Use this for initialization
	void Start () {
		initPos = transform.position;
		if (weight == 0) weight = 1;
	}

	// Update is called once per frame
	void Update () {
		if(chef) transform.position = new Vector3(initPos.x+(chef.transform.position.x - initPos.x)/weight, transform.position.y, transform.position.z);
	}
}
