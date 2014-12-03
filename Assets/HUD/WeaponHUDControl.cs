using UnityEngine;
using System.Collections;

public class WeaponHUDControl : MonoBehaviour {
	public float showTime;
	private float showTimeCountdown;
	public GameObject weaponHud;
	private Vector3 originalPos;
	// Use this for initialization
	void Start () {
		originalPos = new Vector3(weaponHud.transform.position.x, weaponHud.transform.position.y, weaponHud.transform.position.z);
		showTimeCountdown = showTime;
	}
	
	public void showHud(int weaponType){
		weaponHud.transform.position = originalPos;
		showTimeCountdown = showTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(showTimeCountdown > 0) showTimeCountdown -= Time.deltaTime;
		if(showTimeCountdown <= 0 && weaponHud.transform.position.y > originalPos.y - 1){
			weaponHud.transform.position = new Vector3(originalPos.x, weaponHud.transform.position.y-(float)0.01, originalPos.z);
		}
	}
}
