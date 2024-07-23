using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCombustible : MonoBehaviour
{
    public ControlNave controlNave;
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
            controlNave.GetCombustible();
            controlNave.sistemaGuardado.AgregarPuntaje(20);
            gameObject.SetActive(false);
        }
    }
}
