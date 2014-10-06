using UnityEngine;
using System.Collections;

public class WeaponHUD : MonoBehaviour {
	public Attack1 chefAttack;
	public PlayerController chefController;
	public GameObject hud2, hud3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = chefAttack.damage[chefController.weaponChoice].ToString ();
		if (chefAttack.attackType == 0)
						hud2.guiText.text = "Melee";
		else 			hud2.guiText.text = "Ranged";
		hud3.guiText.text = "Descriçao,\n mano!";
	}
}
