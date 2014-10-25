using UnityEngine;
using System.Collections;

public class WeaponHUD3 : MonoBehaviour {
	public playerController_2 chef;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = chef.lastWeaponChoice.ToString();
	}
}
