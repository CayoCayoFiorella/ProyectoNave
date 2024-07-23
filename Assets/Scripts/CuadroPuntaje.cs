using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuadroPuntaje : MonoBehaviour
{
    private TextMeshProUGUI textPuntaje;
    private float puntos;
    
    // Start is called before the first frame update
    void Start()
    {
        textPuntaje= GetComponent<TextMeshProUGUI>();
        puntos= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPuntaje(float p){
        puntos= p;
        textPuntaje.text= puntos.ToString();
    }

    public void AddPuntaje(float p){
        puntos+= p;
        textPuntaje.text= puntos.ToString();
    }
}
