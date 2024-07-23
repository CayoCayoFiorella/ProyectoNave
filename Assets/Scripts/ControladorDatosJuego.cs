using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ControladorDatosJuego : MonoBehaviour
{
    public string file;
    public GameObject inputName;
    public DatosJuego datos = new DatosJuego();
    private void Awake()
    {
        file = Application.dataPath + "/datos.json";
    }
    private void cargarDatos()
    {
        if (File.Exists(file))
        {
            string contenido = File.ReadAllText(file);
            datos = JsonUtility.FromJson<DatosJuego>(contenido);
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }
    private void guardarDatos()
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            
        };
    }
    private string getName()
    {
        string jugador = inputName.GetComponent<TextMeshProUGUI>().text;
        return jugador;
    }
}