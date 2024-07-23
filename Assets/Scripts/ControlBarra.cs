using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBarra : MonoBehaviour
{
    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider= GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarValor(float vida){
        slider.value= vida;
    }

    public void Gastar(float gasto){
        slider.value= slider.value - gasto;
    }

    public float GetValor(){
        return slider.value;
    }
}
