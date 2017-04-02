using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSc : MonoBehaviour {

	public float velocidad = 10; //Definir velocidad
    public string axis = "Horizontal"; //Definir eje 
    public float maxX; //Posicion maxima y minima del movimiento en x
    //Se especifica en que eje se debe dar el movimiento 
    void FixedUpdate () {
        float al = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(al, 0) * velocidad;
        //Limitar el area del jugador
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
        transform.position = pos;
    }

}
