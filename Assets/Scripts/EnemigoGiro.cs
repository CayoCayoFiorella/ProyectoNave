using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoGiro : MonoBehaviour
{
    public float velocidad;
    public float rotationSpeed = 5f;
    public Vector3[] puntos;
    private int siguiente =0;
    private float distMinima= 0.1f;
    private bool estaAtacando= false;
    private GameObject objetivo;


    // Start is called before the first frame update
    void Start()
    {
        Girar();
    }

    // Update is called once per frame
    void Update()
    {
        if(estaAtacando){
            Atacar();
        }else if(puntos.Length > 1){
            Vigilar();
        }else{
            Regresar();
        }
    }

    private void Vigilar(){
        Vector3 direccion= puntos[siguiente];
        transform.position = Vector3.MoveTowards(transform.position, direccion, velocidad*Time.deltaTime);
        
        if(Vector3.Distance(transform.position,direccion) < distMinima){
            siguiente++;
            if(siguiente >= puntos.Length){
                siguiente= 0;
            }
            Girar();
        }
    }

    private void Atacar(){        
        Vector3 direccion= objetivo.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, direccion, velocidad*Time.deltaTime);
        Vector3 direction = (objetivo.transform.position - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(direction.normalized);
        transform.rotation= toRotation;
    }

    public void CambiarEstado(GameObject obj){
        velocidad= 4f;
        rotationSpeed = 3f;
        StartCoroutine(ReducirVelocidad());
        estaAtacando= true;
        objetivo= obj;
        StartCoroutine(Cansarse());
    }

    public void Regresar(){
        Vector3 direccion= puntos[0];
        transform.position = Vector3.MoveTowards(transform.position, direccion, velocidad*Time.deltaTime);
        Vector3 direction = (puntos[0] - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation= toRotation;
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject colisionador=collision.gameObject;
        print("colision");

        if(colisionador.CompareTag("Player")){
            print("Reducir Velocidad");
            StartCoroutine(ReducirVelocidad());
        }
    }

    private void Girar(){
        Vector3 direction = (puntos[siguiente] - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        transform.rotation= toRotation;
        StartCoroutine(ReducirVelocidad());
    }

    IEnumerator ReducirVelocidad(){
        velocidad /= 2;
        yield return new WaitForSeconds(2.0f);
        velocidad *= 2;
    }

    IEnumerator Cansarse(){
        yield return new WaitForSeconds(15.0f);
        estaAtacando= false;
    }
}
