using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    // Start is called before the first frame update
    public ControlNave controlNave;
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
            controlNave.GetKey();
            controlNave.sistemaGuardado.AgregarPuntaje(50);
            gameObject.SetActive(false);
        }
    }
}
