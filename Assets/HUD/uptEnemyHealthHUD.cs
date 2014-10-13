using UnityEngine;
using System.Collections;

public class uptEnemyHealthHUD : MonoBehaviour {
	public GameObject enemy;
	private Vector3 initialScale;

	// Use this for initialization
	void Start () {
		enemy = this.transform.parent.gameObject;
		initialScale = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = enemy.GetComponent<enemyInfo>().health.ToString ();
		if(enemy.GetComponent<doughnutIA2>().Right) transform.localScale = initialScale;
		else transform.localScale = new Vector3 (-initialScale.x, initialScale.y, initialScale.z);		
	}
}
