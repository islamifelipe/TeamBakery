using UnityEngine;
using System.Collections;

public class WeaponHUD : MonoBehaviour {
	public mainAttack chefAttack;
	public playerController_2 chefController;
	public GameObject hud2, hud3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = chefAttack.damage.ToString ();
	}
}
