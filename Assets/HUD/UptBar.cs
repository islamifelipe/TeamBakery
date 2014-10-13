using UnityEngine;
using System.Collections;

public class UptBar : MonoBehaviour {
	public PCInfo chef;
	private float max;
	private float aux;
	private Vector2 initScale, initPos;

	// Use this for initialization
	void Start () {
		max = (float)chef.health;
		initScale = transform.localScale;
		initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		aux = initScale.x * ((float)chef.health / max);
		transform.localScale = new Vector2(aux, initScale.y);
		transform.position = new Vector2(initPos.x -(initScale.x - aux)/2f, initPos.y);	
	}
}
