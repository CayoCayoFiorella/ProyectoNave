using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoGravedad : MonoBehaviour
{
    public ControlNave controlNave;
    public int gravedad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Applies an upwards force to all rigidbodies that enter the trigger.
    void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Player")){   
            Vector3 fuerza= (transform.position - controlNave.transform.position).normalized;  
            controlNave.AplicarFuerza(gravedad*fuerza);
        }
    }
}
