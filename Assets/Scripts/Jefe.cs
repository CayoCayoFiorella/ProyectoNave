using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : MonoBehaviour
{
    public ControlNave controlNave;
    public List<Bloqueo> bloqueos;
    public GameObject objetivo;
    public float velocidad= 0f;
    public AudioSource sonidoChoque, musicaFondo, alarma;
    int vida= 6;
    bool estaAtacando= false;
    float lim= 228.2f;
    bool activeFixedPpdate = false;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(estaAtacando){
            Atacar();
        }
    }

    void FixedUpdate() {
        if(activeFixedPpdate){
            rigidbody.position= new Vector3(Mathf.Clamp(rigidbody.position.x,lim,lim+52),Mathf.Clamp(rigidbody.position.y,-2.6f,29.5f),rigidbody.position.z);
            
            // Obtén la rotación actual de la nave
            Quaternion currentRotation = rigidbody.rotation;

            // Restringe la rotación en los ejes X e Y
            /*float clampedX = Mathf.Clamp(currentRotation.eulerAngles.x, 0f, 0f);
            float clampedY = Mathf.Clamp(currentRotation.eulerAngles.y, 0f, 0f);*/
            Vector3 rotacionActual = transform.rotation.eulerAngles;
            rotacionActual.y = 270f;

            // Crea un nuevo quaternion con las restricciones
            //Quaternion clampedRotation = Quaternion.Euler(clampedX, clampedY, currentRotation.eulerAngles.z);

            // Asigna la nueva rotación a la nave
            //rigidbody.rotation = clampedRotation;
            transform.rotation = Quaternion.Euler(rotacionActual);
        }        
    }

    public void Muerte(){
        estaAtacando= false;
        activeFixedPpdate= false;
        Vector3 empuje= new Vector3(1f,0.5f,0.5f);
        musicaFondo.Stop();
        controlNave.CambiarTema();
        rigidbody.AddForce(200*empuje);
        foreach(Bloqueo b in bloqueos){
            b.CambiarEstado();
        }
    }

    public void CambiarEstado(){
        controlNave.CambiarTema();
        alarma.Play();
        StartCoroutine(InicioBatalla());
    }

    private void Atacar(){        
        Vector3 direccion= objetivo.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, direccion, velocidad*Time.deltaTime);
        Vector3 direction = (objetivo.transform.position - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(direction.normalized);
        transform.rotation= toRotation;
    }

    private void OnCollisionEnter(Collision collision) {
        rigidbody.freezeRotation = true;
        GameObject colisionador=collision.gameObject;

        if(colisionador.CompareTag("ColisionPeligrosa")){
            sonidoChoque.Play();
            Vector3 empuje= transform.position - colisionador.transform.position;
            rigidbody.AddForce(100*empuje);
            vida--;
            if(vida <= 0){
                Muerte();
            }
        } else if(colisionador.CompareTag("Player")){
            Vector3 empuje= transform.position - colisionador.transform.position;
            rigidbody.AddForce(150*empuje);
        }
    }

    IEnumerator InicioBatalla(){
        yield return new WaitForSeconds(4.0f);
        musicaFondo.Play();       
        estaAtacando= true;
        activeFixedPpdate= true;
        velocidad= 7.0f;
    }
}
