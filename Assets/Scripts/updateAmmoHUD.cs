using UnityEngine;
using System.Collections;

public class updateAmmoHUD : MonoBehaviour {
	public GameObject chef;
	
	// Use this for initialization
	void Start () {
		this.guiText.text = chef.GetComponent<projectileAmmoed>().ammo.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = chef.GetComponent<projectileAmmoed>().ammo.ToString();
	}
}
