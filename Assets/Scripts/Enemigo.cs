using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Vector3 origen = new Vector3(0,0,0);
    public float velocidad;
    public Vector3[] puntos;
    public float factorReduccion= 2;
    private int siguiente =0;
    private float distMinima= 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        //Girar();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direccion= puntos[siguiente];
        Vector3 direccion= puntos[siguiente] + origen;
        transform.position = Vector3.MoveTowards(transform.position, direccion, velocidad*Time.deltaTime);
        
        if(Vector3.Distance(transform.position,direccion) < distMinima){
            siguiente++;
            if(siguiente >= puntos.Length){
                siguiente= 0;
            }
            //Girar();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject colisionador=collision.gameObject;
        print("colision");

        if(colisionador.CompareTag("Player")){
            print("Reducir Velocidad");
            StartCoroutine(ReducirVelocidad());
        }
    }

    /*private void Girar(){

    }*/

    IEnumerator ReducirVelocidad(){
        velocidad /= factorReduccion;
        yield return new WaitForSeconds(2.0f);
        velocidad *= factorReduccion;
    }
}
