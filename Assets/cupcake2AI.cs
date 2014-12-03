using UnityEngine;
using System.Collections;

public class cupcake2AI : MonoBehaviour {
	public GameObject chef;
	public float horJump, verJump, jumpDist, walkDist, jumpDelay, walkSpeed;
	private float chefX, thisX, timecounter;
	private int direction;
	
	void Start () {
		timecounter = jumpDelay;
		direction = 1;
		this.GetComponent<enemyInfo>().direction = direction;
	}
	
	void Update () {
		if(Time.timeScale == 1){
			chefX = chef.transform.position.x;
			thisX = this.transform.position.x;
			if (chef.transform.position.x < this.transform.position.x){
				if(direction == 1){
					this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
					direction = -1;
					this.GetComponent<enemyInfo>().direction = direction;
				}
				if(thisX - chefX < jumpDist){
					timecounter -= Time.deltaTime;
					if(timecounter <= 0){
						timecounter = jumpDelay;
						this.rigidbody2D.AddForce(new Vector2(-horJump, verJump));
					}
				}
				else if(thisX - chefX < walkDist){
					timecounter = jumpDelay;
					this.rigidbody2D.velocity = new Vector2(-walkSpeed, this.rigidbody2D.velocity.y);
				}
				else{
					timecounter = jumpDelay;
					this.rigidbody2D.velocity = new Vector2(0, this.rigidbody2D.velocity.y);
				}		
			}
			else{
				if(direction == -1){
					this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
					direction = 1;
					this.GetComponent<enemyInfo>().direction = direction;
				}
				if(chefX - thisX < jumpDist){
					timecounter -= Time.deltaTime;
					if(timecounter <= 0){
						timecounter = jumpDelay;
						this.rigidbody2D.AddForce(new Vector2(horJump, verJump));
					}
				}
				else if(chefX - thisX < walkDist){
					timecounter = jumpDelay;
					this.rigidbody2D.velocity = new Vector2(walkSpeed, this.rigidbody2D.velocity.y);
				}
				else{
					timecounter = jumpDelay;
					this.rigidbody2D.velocity = new Vector2(0, this.rigidbody2D.velocity.y);
				}	
			}
		}
	}
}
