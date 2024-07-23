using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloqueo : MonoBehaviour
{
    public Vector3 ubicacion;
    float velocidad= 10.0f;
    bool cuidar= true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!cuidar){
            Despejar();
        }
    }

    public void Despejar(){
        transform.position = Vector3.MoveTowards(transform.position, ubicacion, velocidad*Time.deltaTime);
    }

    public void CambiarEstado(){
        cuidar= false;
    }
}
