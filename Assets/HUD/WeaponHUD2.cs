using UnityEngine;
using System.Collections;

public class WeaponHUD2 : MonoBehaviour {
	public playerController_2 chef;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = chef.weaponChoice.ToString();
	}
}
