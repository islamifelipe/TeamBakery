using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public float xPos, yPos;
	public GameObject cam;
	public Sprite weapon1, weapon2;
	private int attackType;

	// Use this for initialization
	void Start () {
		attackType = 1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(cam.transform.parent.transform.localPosition.x+xPos, cam.transform.parent.transform.localPosition.y+yPos, 1);
		if (Input.GetKeyDown (KeyCode.Q)) {
			if(attackType == 2){
				gameObject.GetComponent<SpriteRenderer>().sprite = weapon1;
				attackType = 1;
			}
			else{
				gameObject.GetComponent<SpriteRenderer>().sprite = weapon2;
				attackType = 2;
			}
		}
	}
}
