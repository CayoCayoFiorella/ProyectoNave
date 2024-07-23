using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public ControlNave controlNave;
    public int indColeccionable;
    public List<EnemigoGiro> guardianes;
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
            controlNave.GetColeccionable(indColeccionable);
            if(guardianes != null){
                foreach(EnemigoGiro g in guardianes){
                    g.CambiarEstado(obj);
                }
            }            
            gameObject.SetActive(false);
        }
    }
}
