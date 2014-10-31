using UnityEngine;
using System.Collections;

public class weaponIcon : MonoBehaviour {
	public Texture inactiveTexture;
	private Texture activeTexture;

	// Use this for initialization
	void Start () {
		activeTexture = this.transform.guiTexture.texture;
	}
	
	public void setActive(){
		this.transform.guiTexture.texture = activeTexture;
	}
	
	public void setInactive(){
		this.transform.guiTexture.texture = inactiveTexture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
