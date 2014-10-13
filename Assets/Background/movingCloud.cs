using UnityEngine;
using System.Collections;

public class movingCloud : MonoBehaviour {
	private Vector3 initPos;
	public float speed, area;
	private float origSpeed;
	public GameObject chef;

	// Use this for initialization
	void Start () {
		initPos = transform.position;
		origSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (chef.transform.localScale.x < 0) {
						if (transform.position.x - initPos.x > area) {
								transform.position = new Vector3 (-initPos.x + (Random.value), initPos.y + (Random.value - 0.5f) * 1.3f, initPos.z);
								speed = origSpeed + (Random.value - 0.5f) * origSpeed / 5;
						} else
								transform.position = new Vector3 (-transform.position.x - speed, transform.position.y, transform.position.z);
				} else {
			if (transform.position.x - initPos.x > area) {
				transform.position = new Vector3 (initPos.x - (Random.value), initPos.y + (Random.value - 0.5f) * 1.3f, initPos.z);
				speed = origSpeed + (Random.value - 0.5f) * origSpeed / 5;
			} else
				transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
				}
	}
}