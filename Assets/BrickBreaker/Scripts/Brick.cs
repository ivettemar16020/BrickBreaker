using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int vidaB; //Contador de vidas de los ladrillos
	//Los ladrillos celeste tienen una vida
	//Los ladrillos grises tienen dos vidas
	//Los ladrillos morados tienen tres vidas

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Metodo de colision
	void OnCollisionEnter2D(Collision2D col){
		//Si la pelota colisiona en cualquiera de los ladrillos
		if (col.gameObject.tag == "Ball") {
			//Se le resta uno al contador de las vidas
			vidaB = vidaB -1;
			if (vidaB == 0){ //Si los bricks se quedan sin vidas
				//Destruir el brick
            	Destroy (gameObject); 
			}

		}


	}

	
}
