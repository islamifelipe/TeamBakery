using UnityEngine;
using System.Collections;

public class uptEnemyHealthHUD : MonoBehaviour {
	public GameObject enemy;
	public int direction;

	// Use this for initialization
	void Start () {
		direction = 1;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = enemy.GetComponent<enemyInfo>().health.ToString();
		if(direction + enemy.GetComponent<enemyInfo>().direction == 0){
			direction *= -1;
			this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
		}
	}
}
