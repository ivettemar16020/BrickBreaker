using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bola : MonoBehaviour {
	//Determinar que variables publicas se utilizaran 
	public Rigidbody2D bola;
	public float velocidad;	
	public int vida;

	bool iniciar = false; //Boolean que indica el inicio del juego
	private int puntos; //Contador de puntos

	 void Start ()
    {
        puntos = 0; //Iniciar el contador en 0
    }

	//Update is called once per frame
	void Update () {
		//Hacer que el juego empiece cuando se presiona la tecla espaciadora
		if( Input.GetKeyUp(KeyCode.Space) && iniciar == false ){
			//Hacer que la pelotita se empiece a mover desde la posicion que el jugador ya eligio
			transform.SetParent (null);
			bola.isKinematic = false; //Se le debe deshabilitar isKinematic
	        
	        GetComponent<Rigidbody2D>().velocity = Vector2.up * velocidad; 
			
			iniciar = true;
		}
			
		if(Input.GetKey(KeyCode.R)) {
            //Se reinicia el juego al presionar la tecla R
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        // ||  1 <- arriba 
        // ||  0 <- en medio 
        // || -1 <- abajo
        return (ballPos.y - racketPos.y) / racketHeight;
    }

	void OnCollisionEnter2D(Collision2D col){
		//Si la bola colisiona con el paddle
		if(col.gameObject.tag == "Jugador"){
			 // Calcula hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calcular direccion 
            Vector2 dir = new Vector2(1, y).normalized;

            // Velocidad
            GetComponent<Rigidbody2D>().velocity = dir * velocidad;
		}

		//Si la bola colisiona con el limite inferior 
		if(col.gameObject.tag == "Pared")
		{
			//Manejo de las vidas 
			vida = vida - 1; //Restar al contador de vidas
			GameObject vidas = GameObject.Find("Vida");
            vidas.GetComponent<TextMesh>().text = "Vida: " + vida; 
            if (vida == 0){
            	Destroy(gameObject); //Destruir la pelota
            	GameObject gameOver = GameObject.Find("GameOver");
            	gameOver.GetComponent<TextMesh>().text = "Game Over"; //Mostrar mensaje en pantalla
            }

		}

		//Si la bola colisiona con el brick 
		if(col.gameObject.name.Contains("Brick"))
		{
			puntos = puntos + 10; //Sumar 10 al contador de puntos
			GameObject punteo = GameObject.Find("Punteo");
	        punteo.GetComponent<TextMesh>().text = "Puntos: " + puntos; // Actulizar el texto con el nuevo punteo
	        if (puntos == 400){
            	Destroy(gameObject);
            	GameObject gameOver = GameObject.Find("GameOver");
            	gameOver.GetComponent<TextMesh>().text = " GANASTE!"; //Mostrar mensaje en pantalla
            }

		}
	}
}

