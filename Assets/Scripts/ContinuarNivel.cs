using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuarNivel : MonoBehaviour
{
    public AudioSource sonidoPositivo, sonidoNegativo;
    public ControlNave controlNave;
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Player")){            
            bool tieneLlave= controlNave.HasKey();
            if(tieneLlave){
                print("Ganaste");
                sonidoPositivo.Play();
                controlNave.Continuar(transform.position,transform.position-camara.transform.position);
            }else{
                print("No tienes llave");
                sonidoNegativo.Play();
            }
        }
    }
}
