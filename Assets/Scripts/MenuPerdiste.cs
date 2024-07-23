using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPerdiste : MonoBehaviour
{
    public GameObject menu;
    public GameObject pausa;
    bool pausado= false;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && !pausado){
            pausado= true;
            print("Pausado");
            Pausar();
        }
    }
    
    public void Salir(){
        print("Saliendo");
        Time.timeScale= 1.0f;
        SceneManager.LoadScene("MenuNiveles");
    }

    public void Reiniciar(){
        print("Reinciando");
        Time.timeScale= 1.0f;
        pausado = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Mostrar(){
        Time.timeScale= 0.0f;
        menu.SetActive(true);
    }

    public void Pausar(){
        print("Pausado");
        Time.timeScale= 0.0f;
        pausa.SetActive(true);
    }

    public void Continuar(){
        pausa.SetActive(false);
        pausado = false;
        Time.timeScale= 1.0f;
    }
}
