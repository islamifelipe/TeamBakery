using UnityEngine;
using System.Collections;

public class WeaponHUD1 : MonoBehaviour {
	public mainAttack chefAttack;
	public playerController_2 chefController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = chefAttack.damage.ToString ();
	}
}
