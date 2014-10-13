using UnityEngine;
using System.Collections;

public class Projetil : MonoBehaviour {

	public Rigidbody projetil2;
	public Vector3 vel;
	
	private float distanciaPlayer = 1.3f; //Distancia que iremos gerar o projétil do jogador

	void Start () {
		vel.x = 18;
		vel.y = 2;
		vel.z = 0;
		projetil2.AddForce(vel,ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Tiro")) {
			Rigidbody clone = (Rigidbody) Instantiate(projetil2, new Vector3(transform.position.x,transform.position.y + distanciaPlayer,transform.position.z), transform.rotation);
			Destroy(clone.gameObject, 2.0f);
			/* Problemas: 
			 * 	==> detectar colisao do projetil e destruir-lo (retirar da memoria)
			 *  ==> atirar objeto para o sentido da velocidade do protagonista
			 *  ==> Projetil esta clonando todos os projeteis que estao na memoria (ruim)
			 */

			//clone.AddForce(transform.TransformDirection(Vector3.up) * velocidade);
			//clone.AddForce(vel,ForceMode.VelocityChange);
		}
	}
}
