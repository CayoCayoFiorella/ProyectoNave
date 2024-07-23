using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoPrueba : MonoBehaviour
{
    public GameObject player, instrucciones1, instrucciones2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("¡Alerta de portal!");
            if(Vector3.Distance(player.transform.position, transform.position)> 0.2f){
                instrucciones1.SetActive(false);
                instrucciones2.SetActive(true);
            }
        }
    }
}
