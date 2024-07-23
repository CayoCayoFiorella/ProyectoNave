using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoJefe : MonoBehaviour
{
    public Jefe jefe;
    public GameObject portal;
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
            portal.SetActive(false);
            jefe.CambiarEstado();
            gameObject.SetActive(false);
        }
    }
}
