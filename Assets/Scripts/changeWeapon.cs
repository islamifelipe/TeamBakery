using UnityEngine;
using System.Collections;

public class changeWeapon : MonoBehaviour {
	public GameObject weaponLeft, weaponRight;
	private Texture aux;

	void Start () {	
	}
	
	public void swapLeft(){
		aux = this.guiTexture.texture;
		this.guiTexture.texture = weaponRight.guiTexture.texture;
		weaponRight.guiTexture.texture = weaponLeft.guiTexture.texture;
		weaponLeft.guiTexture.texture = aux;
	}
	
	public void swapRight(){
		aux = this.guiTexture.texture;
		this.guiTexture.texture = weaponLeft.guiTexture.texture;
		weaponLeft.guiTexture.texture = weaponRight.guiTexture.texture;
		weaponRight.guiTexture.texture = aux;	
	}
	
	void Update () {
	}
}