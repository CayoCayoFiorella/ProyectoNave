using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsula : MonoBehaviour
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
            bool tieneLlave= controlNave.HasKey();
            if(tieneLlave){
                print("Ganaste");
            }else{
                print("No tienes llave");
            }
        }
    }
}
