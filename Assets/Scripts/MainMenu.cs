using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelJugar;
    public GameObject panelNewPlayer;
    public GameObject panelLoadPlayer;
    public GameObject panelAbout;
    public GameObject LevelImage;
    public GameObject LevelText;
    private int nivelSeleccionado;
    // Start is called before the first frame update
    void Start()
    {
        nivelSeleccionado = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CargarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void CargarEscenaNivel()
    {
        SceneManager.LoadScene("Nivel" + nivelSeleccionado);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void cambiarPaneles(int ind)
    {
        switch (ind) 
        {
            case 1: // Entrar al panel de juegos
                panelJugar.SetActive(true);
                panelInicio.SetActive(false);
                panelNewPlayer.SetActive(false);
                panelLoadPlayer.SetActive(false);
                panelAbout.SetActive(false);
                break;
            case 2: // Entrar al panel principal
                panelInicio.SetActive(true);
                panelJugar.SetActive(false);
                panelAbout.SetActive(false);
                break;
            case 3: // Entrar al panel newPlayer
                panelNewPlayer.SetActive(true);
                break;  
            case 4: // Entrar al panel loadPlayer
                panelLoadPlayer.SetActive(true);
                break;
            case 5: // Entrar al panel about
                panelAbout.SetActive(true);
                break;
        }
    }
    IEnumerator wait() 
    { 
        yield return new WaitForSeconds(1);
    }
    public void changeLevel(int l)
    {
        string information = "";
        nivelSeleccionado = l;
        Sprite image = Resources.Load<Sprite>("Sprites/level" + l);
        LevelImage.GetComponent<Image>().sprite = image;
        switch (l)
        {
            case 0:
                information = "Nivel para aprender la mecánica básica del juego";
                break;
            case 1:
                information = "Tu viaje comienza aqu�, en el espacio infinito. Abordo de tu nave, " +
                              "explorar�s el cosmos para as� encontrar la voltarita " +
                              "necesaria para la supervivencia de la humanidad.";
                break;
            case 2:
                information = "Encontrar las primeras muestras de voltarita no fue sencillo, hallaste " +
                              "peligros desconocidos que lograste superar, y a pesar de que " +
                              "deser�as regresar, debes seguir con la b�squeda, por el futuro de tu especie.";
                break;
            case 3:
                information = "La situaci�n se vuelve cada vez m�s complicada, y no est�s seguro de si lograras " +
                              "salir con vida, pero ya superaste la mitad de tu viaje, y eso te entusiasma " +
                              "por que pronto regresar�s con tu familia.";
                break;
            case 4:
                information = "Estas en la parte final de tu traves�a, y crees que nada te podr� detener, " +
                              "sin embargo tienes el presentimiento de que tus enemigos no te lo dejaran tan f�cil, " +
                              "una gran sorpresa nos espera...";
                break;
        }
        LevelText.GetComponent<TextMeshProUGUI>().text = information;
    }
    public int getLevel() 
    {
        return nivelSeleccionado;
    }
}
