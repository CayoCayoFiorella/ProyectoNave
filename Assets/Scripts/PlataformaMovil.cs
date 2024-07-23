using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento de la plataforma
    public float distancia = 20f; // Distancia total que recorrerá la plataforma

    private Vector3 puntoInicial; // Punto inicial de la plataforma
    private bool moviendoseDerecha = true; // Indica si la plataforma se está moviendo hacia la derecha

    void Start()
    {
        puntoInicial = transform.position; // Guarda la posición inicial
    }

    void Update()
    {
        // Calcula el nuevo desplazamiento
        float desplazamiento = velocidad * Time.deltaTime;

        // Actualiza la posición de la plataforma en el eje X
        if (moviendoseDerecha)
            transform.Translate(Vector3.right * desplazamiento);
        else
            transform.Translate(Vector3.left * desplazamiento);

        // Verifica si la plataforma ha alcanzado el límite de distancia
        if (Mathf.Abs(transform.position.x - puntoInicial.x) >= distancia / 2)
        {
            // Cambia la dirección de movimiento
            moviendoseDerecha = !moviendoseDerecha;
        }
    }
}
